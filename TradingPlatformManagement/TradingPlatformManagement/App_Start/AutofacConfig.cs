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
using TPM.DataAccessFramework.Providers;
using TPM.DataModel.Models;

namespace TradingPlatformManagement.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureDI() =>
            DependencyResolver.SetResolver(new AutofacDependencyResolver(BuildContainer()));

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(r => new TradingPlatformManagementEntities()).As<TradingPlatformManagementEntities>();

            builder.Register(r => new BiddingProvider(r.Resolve<TradingPlatformManagementEntities>())).As<IBiddingProvider>().InstancePerDependency();

            builder.RegisterType<HomeController>().InstancePerDependency();
            builder.RegisterType<BiddingController>().InstancePerDependency();

            return builder.Build();
        }
    }
}