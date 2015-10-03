using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Ninject;
using Ninject.Modules;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    //public class ProcessorModule : INinjectModule
    //{
    //    private readonly Assembly _serviceAssembly;

    //    public ProcessorModule(Assembly serviceAssembly)
    //    {
    //        _serviceAssembly = serviceAssembly;
    //        Name = "ProcessorModule";
    //    }

    //    public IKernel Kernel { get; private set; }

    //    public void OnLoad(IKernel kernel)
    //    {
    //        kernel.Bind<IMappingEngine>().ToConstant(AutoMapper.Mapper.Engine);
    //        kernel.Bind<IUniversalMapper>().To<UniversalMapper>().InTransientScope();

    //        kernel.Bind<IRepositoryProvider>()
    //            .To<RepositoryProvider>()
    //            .WithConstructorArgument(new RepositoryFactories());

    //        kernel.Bind<IDataContextAsync>().To<HomeLibraryContext>().InTransientScope();
    //        kernel.Bind<IUnitOfWorkAsync>().To<UnitOfWork>().InTransientScope();

    //        AutoRegisterType(kernel, typeof (IQueryHandler<,>));
    //        AutoRegisterType(kernel, typeof (ICommandHandler<>));
    //    }

    //    /// <summary>
    //    /// From http://stackoverflow.com/a/13859582/540156, as updated by me with expression-style syntax
    //    /// </summary>
    //    /// <param name="type"></param>
    //    private void AutoRegisterType(IKernel kernel, Type type)
    //    {
    //        // All the handlers (both query and command) live in the Services assembly.
    //        var handlerRegistrations = _serviceAssembly.GetExportedTypes()
    //            .Where(x => !x.IsAbstract)
    //            .Where(x => !x.ContainsGenericParameters)
    //            .SelectMany(x => x.GetInterfaces()
    //                .Where(i => i.IsGenericType)
    //                .Where(i => i.GetGenericTypeDefinition() == type)
    //                .Select(i => new { service = i, implementation = x })
    //            );

    //        foreach (var registration in handlerRegistrations)
    //        {
    //            kernel.Bind(registration.service).To(registration.implementation);
    //        }
    //    }


    //    public void OnUnload(IKernel kernel)
    //    {
    //        //throw new NotImplementedException();
    //    }

    //    public void OnVerifyRequiredModules()
    //    {
    //        //throw new NotImplementedException();
    //    }

    //    public string Name { get; private set; }
    //}
}
