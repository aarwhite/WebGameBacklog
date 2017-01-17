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
using WebGameBacklog.Shared.Persistence;
using WebGameBacklog.Services.Games;
using WebGameBacklog.Persistence.Repositories;
using Castle.Core;

namespace WebGameBacklog.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            //Register all controllers
            container.Register(

            //Nhibernate session factory
            Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton,

                Component.For<NhUnitOfWorkInterceptor>().LifeStyle.Transient,

                //All repoistories
                Classes.FromAssembly(Assembly.GetAssembly(typeof(GameBacklogRepository)))
                    .InSameNamespaceAs<GameBacklogRepository>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),

                //All services
                Classes.FromAssembly(Assembly.GetAssembly(typeof(GameBacklogService)))
                    .InSameNamespaceAs<GameBacklogService>()
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

        void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
            }

            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                    return;
                }
            }
        }
    }
}
