using MyStorage.Models;
using MyStorage.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MyStorage
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
     //       container.RegisterType<IRepository<Product>, SqlDbProductRespository>();
            container.RegisterType<IRepository<Product>, JsonProductRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}