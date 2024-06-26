using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Hao.MES.Extension.AOP;
using Hao.MES.IService;
using Hao.MES.Repository;
using Hao.MES.Service;
using Module = Autofac.Module;

namespace Hao.MES.Extension.AutoFac;

public class AutoFacModuleRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var basePath = AppContext.BaseDirectory;

        var serviceDllFile = Path.Combine(basePath, "Hao.MES.Service.dll");
        var repositoryDllFile = Path.Combine(basePath, "Hao.MES.Repository.dll");

        var aopTypes = new List<Type> { typeof(ServiceAOP) };
        builder.RegisterType<ServiceAOP>();
        
        builder.RegisterGeneric(typeof(BaseRepository<>))
            .As(typeof(IBaseRepository<>))
            .InstancePerDependency();
        
        builder.RegisterGeneric(typeof(BaseService<,>))
            .As(typeof(IBaseService<,>))
            .InstancePerDependency()            
            .EnableInterfaceInterceptors()
            .InterceptedBy(aopTypes.ToArray());

        var assemblysService = Assembly.LoadFrom(serviceDllFile);
        builder.RegisterAssemblyTypes(assemblysService)
            .AsImplementedInterfaces() //接口
            .InstancePerDependency() //瞬态模式
            .PropertiesAutowired()
            .EnableInterfaceInterceptors()
            .InterceptedBy(aopTypes.ToArray()); //属性注入

        var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
        builder.RegisterAssemblyTypes(assemblysRepository)
            .AsImplementedInterfaces()
            .InstancePerDependency()
            .PropertiesAutowired();
    }
}