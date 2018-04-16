using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using CelebBLL;
using MortgageCalculator.RestApi.Web.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CelebritiesAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));

            container.Register(Component.For<ICelebCRUD>().ImplementedBy<CelebCRUD>().LifestyleSingleton());
            
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleScoped()
                );
            var dependencyResolver = new WindsorDependencyResolver(container.Kernel);

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
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
