using Autofac;
using Autofac.Integration.WebApi;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using TradingPlatformManagement.Controllers;

namespace TradingPlatformManagement.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureDI() =>
            DependencyResolver.SetResolver(new AutofacDependencyResolver(BuildContainer()));

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HomeController>().InstancePerDependency();

            return builder.Build();
        }
    }
}