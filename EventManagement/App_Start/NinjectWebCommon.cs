using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using System.Web.WebPages;
using Ninject.Web.Common.WebHost;
using EventManagement.DB.Interfaces;
using EventManagement.DB.Repository;
using System.Web.Http;

[assembly: WebActivator.PreApplicationStartMethod(typeof(EventManagement.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(EventManagement.App_Start.NinjectWebCommon), "Stop")]

namespace EventManagement.App_Start
{
    

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {

            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
            //{
            //    ContextCondition = (context => context.GetOverriddenUserAgent()
            //        .IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0)
            //});

            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IAuthRepository>().To<AuthRepository>();
            kernel.Bind<IAudienceRepository>().To<AudienceRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}
