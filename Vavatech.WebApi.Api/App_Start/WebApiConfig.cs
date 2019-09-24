using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Vavatech.WebApi.Api.Resolvers;
using Vavatech.WebApi.FakeRepositories;
using Vavatech.WebApi.Fakers;
using Vavatech.WebApi.IRepositories;

namespace Vavatech.WebApi.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            IUnityContainer container = new UnityContainer();

            //container.RegisterType<IProductRepository, FakeProductRepository>();
            //container.RegisterType<ProductFaker>();

            container.RegisterSingleton<IProductRepository, FakeProductRepository>();
            container.RegisterSingleton<ProductFaker>();

            container.RegisterSingleton<ICustomerRepository, FakeCustomerRepository>();
            container.RegisterSingleton<CustomerFaker>();

            config.DependencyResolver = new UnityDependencyResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
