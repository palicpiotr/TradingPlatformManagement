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
using TPM.DataAccessFramework.Providers.Biddings;
using TPM.DataAccessFramework.Providers.BiddingTypes;
using TPM.DataAccessFramework.Providers.Companies;
using TPM.DataAccessFramework.Providers.Countries;
using TPM.DataAccessFramework.Providers.Persons;

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
            builder.Register(r => new BiddingTypesProvider(r.Resolve<TradingPlatformManagementEntities>())).As<IBiddingTypesProvider>();
            builder.Register(r => new CompanyProvider(r.Resolve<TradingPlatformManagementEntities>())).As<ICompanyProvider>();
            builder.Register(r => new CountryProvider(r.Resolve<TradingPlatformManagementEntities>())).As<ICountryProvider>();
            builder.Register(r => new PersonProvider(r.Resolve<TradingPlatformManagementEntities>())).As<IPersonProvider>();

            builder.RegisterType<HomeController>().InstancePerDependency();
            builder.RegisterType<BiddingController>().InstancePerDependency();
            builder.RegisterType<AccountController>().InstancePerDependency();
            builder.RegisterType<BiddingTypeController>().InstancePerDependency();
            builder.RegisterType<CompanyController>().InstancePerDependency();
            builder.RegisterType<CountryController>().InstancePerDependency();
            builder.RegisterType<AgriculturalController>().InstancePerDependency();
            builder.RegisterType<CapitalRepairController>().InstancePerDependency();
            builder.RegisterType<ComercialController>().InstancePerDependency();
            builder.RegisterType<CorporateStoreController>().InstancePerDependency();
            builder.RegisterType<GovernmentController>().InstancePerDependency();
            builder.RegisterType<ImmutableController>().InstancePerDependency();
            builder.RegisterType<PersonController>().InstancePerDependency();

            return builder.Build();
        }
    }
}