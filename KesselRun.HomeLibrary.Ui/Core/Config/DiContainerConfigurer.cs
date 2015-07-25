using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.CommandHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Converters;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.QueryHandlers.Decorators;
using KesselRun.HomeLibrary.Service.Validation;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.UnitOfWork;
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
            _container.RegisterType<ILendingsConverters, LendingsConverters>(new TransientLifetimeManager());

            _container.RegisterInstance<IMappingEngine>(AutoMapper.Mapper.Engine)
                .RegisterType<IUniversalMapper, UniversalMapper>(new TransientLifetimeManager());

            _container.RegisterType<IRepositoryProvider, RepositoryProvider>(
                new TransientLifetimeManager(),
                new InjectionMember[] { new InjectionConstructor(new RepositoryFactories()) }
                );

            _container.RegisterType<IDataContextAsync, HomeLibraryContext>(new TransientLifetimeManager());
            _container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new TransientLifetimeManager());

            _container.RegisterType<IQueryProcessor, QueryProcessor>(new TransientLifetimeManager());
            _container.RegisterType<ICommandProcessor, CommandProcessor>(new TransientLifetimeManager());
            
            RegisterValidators();

        }

        private void RegisterValidators()
        {
            _container.RegisterType<IValidator<AddLendingCommand>, AddLendingValidator>(new TransientLifetimeManager());
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
                _container.RegisterType(
                    registration.service,
                    registration.implementation,
                    type.Name + Registration,
                    new TransientLifetimeManager());
            }

            if (type == typeof(IQueryHandler<,>))
            {
                // Decorate each returned IQueryHandler<T> object with an
                // QueryHandlerValidatorDecorator<T>.
                _container.RegisterType(
                    type,
                    typeof(QueryHandlerValidatorDecorator<,>),
                    Service.Infrastructure.Constants.Queryor,
                    new InjectionMember[] { new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration)) }
                    );
                _container.RegisterType(
                    type,
                    typeof(QueryHandlerProfilerDecorator<,>),
                    Service.Infrastructure.Constants.QueryProfiler,
                    new InjectionMember[] { new InjectionConstructor(
                        new ResolvedParameter(typeof(IQueryHandler<,>), Service.Infrastructure.Constants.Queryor)) 
                    });
            }
            else if (type == typeof(ICommandHandler<>))
            {
                // Decorate each returned ICommandHandler<T> object with an
                // CommandHandlerValidatorDecorator<T>.
                _container.RegisterType(
                    type,
                    typeof(CommandHandlerValidatorDecorator<>),
                    Service.Infrastructure.Constants.Commander,
                    new InjectionMember[]
                    {
                        new InjectionConstructor(new ResolvedParameter(type, type.Name + Registration), _container)
                    });

            }
        }
    }
}