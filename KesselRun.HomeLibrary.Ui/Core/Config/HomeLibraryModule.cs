using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Configuration;
using KesselRun.HomeLibrary.Service.CommandHandlers;
using KesselRun.HomeLibrary.Service.CommandHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.QueryHandlers.Decorators;
using Ninject;
using Ninject.Modules;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Linq;
using System.Reflection;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class HomeLibraryModule : INinjectModule
    {
        public IKernel Kernel { get; private set; }

        public HomeLibraryModule()
        {
            Name = "MainModule";
        }

        public string Name { get; private set; }

        public void OnLoad(IKernel kernel)
        {
            Assembly serviceAssembly = typeof(LendingsCommandHandlers).Assembly;

            ManualRegistrations(kernel);

            //Auto-Register all the validators which are stored in the Service assembly.
            AssemblyScanner.FindValidatorsInAssembly(serviceAssembly).ForEach(
                    result => kernel.Bind(result.InterfaceType).To(result.ValidatorType)
                );

            AutoRegisterType(serviceAssembly, kernel, typeof(IQueryHandler<,>), WrapDecoratorsForQueryHandlers);
            AutoRegisterType(serviceAssembly, kernel, typeof(ICommandHandler<>), WrapDecoratorsForCommandHandlers);
        }

        private void ManualRegistrations(IKernel kernel)
        {
            //Kernel.Bind<INavigator, Navigator>().;

            kernel.Bind<StandardKernel>().ToSelf().InSingletonScope();
            kernel.Bind<RepositoryFactories>().ToSelf().InTransientScope();

            var config = GetMapperConfiguration();

            kernel.Bind<MapperConfiguration>().ToConstant(config);
            kernel.Bind<IMapper>().ToMethod(ctx => ctx.Kernel.Get<MapperConfiguration>().CreateMapper());

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>().InTransientScope();

            kernel.Bind<IDataContextAsync>()
                .To<HomeLibraryContext>()
                .InScope(x => PresenterBinder.ApplicationState.GetItem<DatabaseContextScope>("DatabaseContextScope"));

            kernel.Bind<IUnitOfWorkAsync>().To<UnitOfWork>().InTransientScope();

            kernel.Bind<TransactionAspectInterceptor>().ToSelf();

            kernel.Bind<IQueryProcessor>().To<QueryProcessor>().InTransientScope();
            kernel.Bind<ICommandProcessor>().To<CommandProcessor>().InTransientScope();
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            Assembly mapperAssembly = typeof(MappingBase).Assembly;

            var profiles = from t in mapperAssembly.GetTypes()
                where typeof (Profile).IsAssignableFrom(t)
                select (Profile) Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            return config;
        }


        /// <summary>
        /// From http://stackoverflow.com/a/13859582/540156, as updated by me with expression-style syntax
        /// </summary>
        /// <param name="serviceAssembly"></param>
        /// <param name="kernel"></param>
        /// <param name="type"></param>
        /// <param name="wrapperAction"></param>
        private void AutoRegisterType(Assembly serviceAssembly, IKernel kernel, Type type, Action<IKernel, IEnumerable<Binding>> wrapperAction)
        {
            // All the handlers (both query and command) live in the Services assembly.
            var handlerRegistrations = serviceAssembly.GetExportedTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.ContainsGenericParameters)
                .SelectMany(x => x.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => i.GetGenericTypeDefinition() == type)
                    .Select(i => new Binding { Service = i, Implementation = x })
                );

            wrapperAction(kernel, handlerRegistrations);
        }

        private static void WrapDecoratorsForQueryHandlers(IKernel kernel, IEnumerable<Binding> handlerRegistrations)
        {
            foreach (var registration in handlerRegistrations)
            {
                kernel.Bind(registration.Service)
                    .To(registration.Implementation)
                    .WhenInjectedInto(typeof(QueryHandlerValidatorDecorator<,>))
                    .InTransientScope();
            }

            kernel.Bind(typeof(IQueryHandler<,>))
                .To(typeof(QueryHandlerValidatorDecorator<,>))
                .WhenInjectedInto(typeof(QueryHandlerProfilerDecorator<,>))
                .InTransientScope();

            kernel.Bind(typeof(IQueryHandler<,>))
                .To(typeof(QueryHandlerProfilerDecorator<,>))
                .InTransientScope();
        }

        private static void WrapDecoratorsForCommandHandlers(IKernel kernel, IEnumerable<Binding> handlerRegistrations)
        {
            foreach (var registration in handlerRegistrations)
            {
                kernel.Bind(registration.Service)
                    .To(registration.Implementation)
                    .WhenInjectedInto(typeof(CommandHandlerValidatorDecorator<>))
                    .InTransientScope();
            }

            kernel.Bind(typeof(ICommandHandler<>))
                .To(typeof(CommandHandlerValidatorDecorator<>))
                .WhenInjectedInto(typeof(CommandHandlerTransactionDecorator<>))
                .InTransientScope();

            kernel.Bind(typeof(ICommandHandler<>))
                .To(typeof(CommandHandlerTransactionDecorator<>))
                .InTransientScope();
        }

        public void OnUnload(IKernel kernel)
        {
            //throw new NotImplementedException();
        }

        public void OnVerifyRequiredModules()
        {
            //throw new NotImplementedException();
        }

        class Binding
        {
            public Type Implementation { get; set; }
            public Type Service { get; set; }
        }
    }
}
