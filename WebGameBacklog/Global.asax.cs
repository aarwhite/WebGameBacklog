using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebGameBacklog.Persistence.Mappings;

namespace WebGameBacklog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var sessionFactory = Fluently.Configure()
                .Database()
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<GameMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                .BuildSessionFactory;
        }
    }
}
