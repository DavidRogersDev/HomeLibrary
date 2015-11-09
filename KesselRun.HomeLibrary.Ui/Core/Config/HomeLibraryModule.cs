using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.CommandHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.QueryHandlers.Decorators;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Linq;
using System.Reflection;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class HomeLibraryModule : INinjectModule
    {
        public IKernel Kernel { get; private set; }
        private readonly Assembly _serviceAssembly = Assembly.Load("KesselRun.HomeLibrary.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

        public HomeLibraryModule()
        {
            Name = "MainModule";
        }

        public void OnLoad(IKernel kernel)
        {
            ManualRegistrations(kernel);

            //Auto-Register all the validators which are stored in the Service assembly.
            AssemblyScanner.FindValidatorsInAssembly(_serviceAssembly).ForEach(
                    result => kernel.Bind(result.InterfaceType).To(result.ValidatorType)
                );

            AutoRegisterType(kernel, typeof(IQueryHandler<,>), WrapDecoratorsForQueryHandlers);
            AutoRegisterType(kernel, typeof(ICommandHandler<>), WrapDecoratorsForCommandHandlers);
        }

        public string Name { get; private set; }

        private void ManualRegistrations(IKernel kernel)
        {
            //Kernel.Bind<INavigator, Navigator>().;
            //Kernel.Bind<ILendingsConverters>().To <LendingsConverters>();
            
            kernel.Bind<StandardKernel>().ToSelf().InSingletonScope();
            kernel.Bind<RepositoryFactories>().ToSelf().InTransientScope();

            kernel.Bind<IMappingEngine>().ToConstant(AutoMapper.Mapper.Engine).InTransientScope();

            kernel.Bind<IUniversalMapper>().To<UniversalMapper>().InTransientScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>().InTransientScope();

            kernel.Bind<IDataContextAsync>().To<HomeLibraryContext>().InSingletonScope();
            kernel.Bind<IUnitOfWorkAsync>().To<UnitOfWork>().InSingletonScope();

            kernel.Bind<TransactionAspectInterceptor>().ToSelf();


            //kernel.Bind<IQueryHandlerFactory>().ToFactory();

            kernel.Bind<IQueryProcessor>().To<QueryProcessor>().InSingletonScope();
            kernel.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
        }


        /// <summary>
        /// From http://stackoverflow.com/a/13859582/540156, as updated by me with expression-style syntax
        /// </summary>
        /// <param name="type"></param>
        private void AutoRegisterType(IKernel kernel, Type type, Action<IKernel, IEnumerable<Binding>> wrapperAction)
        {
            // All the handlers (both query and command) live in the Services assembly.
            var handlerRegistrations = _serviceAssembly.GetExportedTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.ContainsGenericParameters)
                .SelectMany(x => x.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => i.GetGenericTypeDefinition() == type)
                    .Select(i => new Binding{ Service = i, Implementation = x})
                );

            wrapperAction(kernel, handlerRegistrations);
        }

        private static void WrapDecoratorsForQueryHandlers(IKernel kernel, IEnumerable<Binding> handlerRegistrations)
        {
            foreach (var registration in handlerRegistrations)
            {
                kernel.Bind(registration.Service)
                    .To(registration.Implementation)
                    .WhenInjectedInto(typeof (QueryHandlerValidatorDecorator<,>))
                    .InTransientScope();
            }


            kernel.Bind(typeof (IQueryHandler<,>))
                .To(typeof (QueryHandlerValidatorDecorator<,>))
                .WhenInjectedInto(typeof (QueryHandlerProfilerDecorator<,>))
                .InTransientScope();

            kernel.Bind(typeof (IQueryHandler<,>))
                .To(typeof (QueryHandlerProfilerDecorator<,>))
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
    }

    public class Binding
    {
        public Type Implementation { get; set; }         
        public Type Service { get; set; }         
    }
}
