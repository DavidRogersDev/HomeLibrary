using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.CommandHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.QueryHandlers.Decorators;
using Microsoft.Practices.Unity;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private readonly IUnityContainer _container = new UnityContainer();
        private readonly Assembly _serviceAssembly = Assembly.Load("KesselRun.HomeLibrary.Service");

        public DiContainerConfigurer()
        {
        }

        public void Configure()
        {
            PresenterBinder.Factory = new UnityPresenterFactory(_container);

            AssemblyScanner.FindValidatorsInAssembly(_serviceAssembly).ForEach(
                    result => _container.RegisterType(result.InterfaceType, result.ValidatorType, new TransientLifetimeManager())
                );

            ManualRegistrations();

            AutoRegisterType(typeof(IQueryHandler<,>)); // Register IQueryHandlers
            AutoRegisterType(typeof(ICommandHandler<>)); // Register ICommandHandler
        }

        private void ManualRegistrations()
        {
            _container.RegisterType<IUnityContainer, UnityContainer>(new TransientLifetimeManager());
            _container.RegisterType<INavigator, Navigator>(new TransientLifetimeManager());

            _container.RegisterInstance<IMappingEngine>(AutoMapper.Mapper.Engine)
                .RegisterType<IUniversalMapper, UniversalMapper>(new TransientLifetimeManager());

            _container.RegisterType<IRepositoryProvider, RepositoryProvider>(
                new TransientLifetimeManager(),
                new InjectionMember[] {new InjectionConstructor(new RepositoryFactories())}
                );

            _container.RegisterType<IEntitiesContext, HomeLibraryContext>(new TransientLifetimeManager());
            _container.RegisterType<IUnitOfWork, UnitOfWork>(new TransientLifetimeManager());

            _container.RegisterType<IQueryProcessor, QueryProcessor>(new TransientLifetimeManager());
            _container.RegisterType<ICommandProcessor, CommandProcessor>(new TransientLifetimeManager());
        }


        /// <summary>
        /// From http://stackoverflow.com/a/13859582/540156, as updated by me
        /// </summary>
        /// <param name="type"></param>
        private void AutoRegisterType(Type type)
        {
            const string Registration = "Registration";

            var handlerRegistrations =
                from implementation in _serviceAssembly.GetExportedTypes()
                where !implementation.IsAbstract
                where !implementation.ContainsGenericParameters
                let services =
                    from iface in implementation.GetInterfaces()
                    where iface.IsGenericType
                    where iface.GetGenericTypeDefinition() == type
                    select iface
                from service in services
                select new {service, implementation};

            foreach (var registration in handlerRegistrations)
            {
                _container.RegisterType(
                    registration.service,
                    registration.implementation,
                    type.Name + Registration,
                    new TransientLifetimeManager());
            }

            if (type == typeof (IQueryHandler<,>))
            {
                // Decorate each returned IQueryHandler<T> object with an
                // ValidationQueryHandlerDecorator<T>.
                _container.RegisterType(
                    type,
                    typeof (QueryHandlerValidatorDecorator<,>),
                    "Queryor",
                    new InjectionMember[] { new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration)) }
                    );
            }
            else if(type == typeof (ICommandHandler<>))
            {
                // Decorate each returned IQueryHandler<T> object with an
                // ValidationQueryHandlerDecorator<T>.
                _container.RegisterType(
                    type,
                    typeof (CommandHandlerValidatorDecorator<>),
                    "Commander",
                    new InjectionMember[]
                    {
                        new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration), _container.Resolve<IUnityContainer>())
                    });

            }
        }
    }
}