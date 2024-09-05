﻿using Microsoft.AspNet.Identity;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac;
using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using devUTEHY.Data;
using devUTEHY.Data.Repositories;
using devUTEHY.Service;
using devUTEHY.App_Start;
using System.Web;
using Microsoft.Owin.Security.DataProtection;

[assembly: OwinStartup(typeof(devUTEHY.App_Start.Startup))]

namespace devUTEHY.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfigureAuth(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<devUTEHYDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(LoaiCongNgheRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(LoaiCongNgheService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}
