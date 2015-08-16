using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.CommandHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Converters;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.QueryHandlers.Decorators;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private static readonly IUnityContainer Container = new UnityContainer();
        private readonly Assembly _serviceAssembly = Assembly.Load("KesselRun.HomeLibrary.Service");

        public DiContainerConfigurer()
        {
            
        }

        public void Configure()
        {
            Trace.TraceInformation("Root Di :" + Container.GetHashCode());
            PresenterBinder.Factory = new UnityPresenterFactory(Container);

            AssemblyScanner.FindValidatorsInAssembly(_serviceAssembly).ForEach(
                    result => Container.RegisterType(result.InterfaceType, result.ValidatorType, new TransientLifetimeManager())
                );

            ManualRegistrations();

            AutoRegisterType(typeof(IQueryHandler<,>)); // Register IQueryHandlers
            AutoRegisterType(typeof(ICommandHandler<>)); // Register ICommandHandler
        }

        private void ManualRegistrations()
        {
            Container.RegisterType<IUnityContainer, UnityContainer>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigator, Navigator>(new TransientLifetimeManager());
            Container.RegisterType<ILendingsConverters, LendingsConverters>(new TransientLifetimeManager());

            Container.RegisterInstance<IMappingEngine>(AutoMapper.Mapper.Engine)
                .RegisterType<IUniversalMapper, UniversalMapper>(new TransientLifetimeManager());

            Container.RegisterType<IRepositoryProvider, RepositoryProvider>(
                new TransientLifetimeManager(),
                new InjectionMember[] { new InjectionConstructor(new RepositoryFactories()) }
                );

            Container.RegisterType<IDataContextAsync, HomeLibraryContext>(new TransientLifetimeManager());
            Container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new TransientLifetimeManager());

            Container.RegisterType<IQueryProcessor, QueryProcessor>(new TransientLifetimeManager());
            Container.RegisterType<ICommandProcessor, CommandProcessor>(new TransientLifetimeManager());
            
            RegisterValidators();

        }

        private IUnityContainer RegisterValidators()
        {
            //var commandDecoratorContainer = Container.CreateChildContainer();
            //commandDecoratorContainer.RegisterType<IValidator<AddLendingCommand>, AddLendingValidator>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IValidator<AddLendingCommand>, AddLendingValidator>(new ContainerControlledLifetimeManager());
            return Container;
        }


        /// <summary>
        /// From http://stackoverflow.com/a/13859582/540156, as updated by me with expression-style syntax
        /// </summary>
        /// <param name="type"></param>
        private void AutoRegisterType(Type type)
        {
            const string Registration = "Registration";

            var handlerRegistrations = _serviceAssembly.GetExportedTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.ContainsGenericParameters)
                .SelectMany(x => x.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => i.GetGenericTypeDefinition() == type)
                    .Select(i => new { service = i, implementation = x })
                    );

            foreach (var registration in handlerRegistrations)
            {
                Container.RegisterType(
                    registration.service,
                    registration.implementation,
                    type.Name + Registration,
                    new TransientLifetimeManager());
            }

            if (type == typeof(IQueryHandler<,>))
            {
                // Decorate each returned IQueryHandler<T> object with an
                // QueryHandlerValidatorDecorator<T>.
                Container.RegisterType(
                    type,
                    typeof(QueryHandlerValidatorDecorator<,>),
                    Service.Infrastructure.Constants.Queryor,
                    new ContainerControlledLifetimeManager(),
                    new InjectionMember[] { new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration)) }
                    );
                Container.RegisterType(
                    type,
                    typeof(QueryHandlerProfilerDecorator<,>),
                    Service.Infrastructure.Constants.QueryProfiler,
                    new ContainerControlledLifetimeManager(),
                    new InjectionMember[] { new InjectionConstructor(
                        new ResolvedParameter(typeof(IQueryHandler<,>), Service.Infrastructure.Constants.Queryor)) 
                    });
            }
            else if (type == typeof(ICommandHandler<>))
            {
                RegisterValidators();
                // Decorate each returned ICommandHandler<T> object with an
                // CommandHandlerValidatorDecorator<T>.
                Container.RegisterType(
                    type,
                    typeof(CommandHandlerValidatorDecorator<>),
                    Service.Infrastructure.Constants.Commander,
                    new ContainerControlledLifetimeManager(),
                    new InjectionMember[]
                    {
                        new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration), new ResolvedParameter(typeof(IUnityContainer)))
                    });

            }
        }
    }
}