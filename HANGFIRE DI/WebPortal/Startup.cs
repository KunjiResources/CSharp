using Contract;
using Hangfire;
using Hangfire.StructureMap;
using Microsoft.Owin;
using Owin;
using StructureMap;
using System;
using WebPortal.DependencyResolution;
using WebPortal;
[assembly: OwinStartupAttribute(typeof(WebPortal.Startup))]
namespace WebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //register Sql server database for your hangfire
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=XIDP-IND-APT120\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
            //Register IOC Container
            IContainer container = IoC.Initialize();
            GlobalConfiguration.Configuration.UseStructureMapActivator(container);
            //register hangfire Dashboard
            app.UseHangfireDashboard();
            //register hangfire server
            app.UseHangfireServer();

            // add jobs here
            RecurringJob.AddOrUpdate<ITest>("test", x => x.Hello("hello this is a testiong job"),Cron.Minutely);
             
        }
    }
}
