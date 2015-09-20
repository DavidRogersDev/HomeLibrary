using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Ninject;
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
        private readonly Assembly _serviceAssembly = Assembly.Load("KesselRun.HomeLibrary.Service");

        public HomeLibraryModule()
        {
            Name = "MainModule";
        }

        public void OnLoad(IKernel kernel)
        {
            //  Auto-Register all the validators which are stored in the Service assembly.
            AssemblyScanner.FindValidatorsInAssembly(_serviceAssembly).ForEach(
                    result => kernel.Bind(result.InterfaceType, result.ValidatorType)
                );
            
            ManualRegistrations(kernel);

            //kernel.Bind<IKernelFactory>().ToFactory();

            AutoRegisterType(kernel, typeof(IQueryHandler<,>));
            AutoRegisterType(kernel, typeof(ICommandHandler<>));
        }

        public string Name { get; private set; }

        private void ManualRegistrations(IKernel kernel)
        {
            //Kernel.Bind<INavigator, Navigator>().;
            //Kernel.Bind<ILendingsConverters>().To <LendingsConverters>();

            kernel.Bind<StandardKernel>().ToSelf().InTransientScope();
            kernel.Bind<RepositoryFactories>().ToSelf().InTransientScope();

            kernel.Bind<IMappingEngine>().ToConstant(AutoMapper.Mapper.Engine).InTransientScope();

            kernel.Bind<IUniversalMapper>().To<UniversalMapper>().InTransientScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>().InTransientScope();

            kernel.Bind<IDataContextAsync>().To<HomeLibraryContext>().InTransientScope();
            kernel.Bind<IUnitOfWorkAsync>().To<UnitOfWork>().InTransientScope();
            
            //kernel.Bind<IQueryHandlerFactory>().ToFactory();

            kernel.Bind<IQueryProcessor>().To<QueryProcessor>().InTransientScope();
            kernel.Bind<ICommandProcessor>().To<CommandProcessor>().InTransientScope();
        }


        /// <summary>
        /// From http://stackoverflow.com/a/13859582/540156, as updated by me with expression-style syntax
        /// </summary>
        /// <param name="type"></param>
        private void AutoRegisterType(IKernel kernel, Type type)
        {
            // All the handlers (both query and command) live in the Services assembly.
            var handlerRegistrations = _serviceAssembly.GetExportedTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.ContainsGenericParameters)
                .SelectMany(x => x.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => i.GetGenericTypeDefinition() == type)
                    .Select(i => new {service = i, implementation = x})
                );

            foreach (var registration in handlerRegistrations)
            {
                kernel.Bind(registration.service).To(registration.implementation);
            }
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
}
