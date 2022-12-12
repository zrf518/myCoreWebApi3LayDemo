using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using System.Reflection;
namespace Jason.TestDemo.WebApi
{
    public  class AutoFacContainerInit:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assmbly = Assembly.Load("Jason.TestDemo.Application");

          builder.RegisterAssemblyTypes(assmbly).Where(c=>c.Name.EndsWith("Service")).AsImplementedInterfaces().PropertiesAutowired();
            //base.Load(builder);
        }
        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
        {
            //Console.WriteLine("=====Autofac Register Success!!!=======");
            base.AttachToComponentRegistration(componentRegistry, registration);
        }

        ///// <summary>
        ///// 3.1 静态处理
        ///// </summary>
        ///// <param name="builder"></param>
        //public  void DependencyInJectionByAutoFact(this ContainerBuilder builder)
        //{
        //    var assembly = Assembly.Load("Jason.TestDemo.Application");
        //    //.Where(c=>c.Name.Contains(""))
        //    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        //}
    }
}
