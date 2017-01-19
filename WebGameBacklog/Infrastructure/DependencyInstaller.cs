using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using System.Reflection;
using WebGameBacklog.Persistence.Mappings;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;

namespace WebGameBacklog.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Register all controllers
            container.Register(

                //Nhibernate session factory
                Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton,
                
                //All repoistories
                Classes.FromAssembly(Assembly.GetAssembly(typeof(Persistence.Repositories.GameBacklogRepository)))
                    .InSameNamespaceAs<Persistence.Repositories.GameBacklogRepository>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),

                //All services
                Classes.FromAssembly(Assembly.GetAssembly(typeof(Services.Games.GameBacklogService)))
                    .InSameNamespaceAs<Services.Games.GameBacklogService>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),

                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()

                );
        }

        private static ISessionFactory CreateNhSessionFactory()
        {
            var connStr = ConfigurationManager.ConnectionStrings["GameBacklog"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(GameMap))))
                .BuildSessionFactory();
        }
    }
}
