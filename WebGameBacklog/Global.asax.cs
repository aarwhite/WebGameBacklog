using Castle.Windsor;
using Castle.Windsor.Installer;
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
using WebGameBacklog.Infrastructure;
using WebGameBacklog.Persistence.Mappings;

namespace WebGameBacklog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer _windsorContainer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeWindsor();

            //var sessionFactory = Fluently.Configure()
            //    .Database()
            //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<GameMap>())
            //    .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
            //    .BuildSessionFactory;
        }

        protected void Application_End()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }
        }

        private void InitializeWindsor()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(new DependencyInstaller());

            ControllerBuilder.Current.SetControllerFactory(
                new WindsorControllerFactory(_windsorContainer.Kernel));
        }
    }
}
