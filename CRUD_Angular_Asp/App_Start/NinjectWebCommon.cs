[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CRUD_Angular_Asp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CRUD_Angular_Asp.App_Start.NinjectWebCommon), "Stop")]




namespace CRUD_Angular_Asp.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using CRUD_Angular_Asp.Services;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.NinjectHttpModule));
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //web api ak
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //role
            kernel.Bind<IStudentServices>().To<StudentServices>();
            kernel.Bind<StudentServices>().To<StudentServices>();

        }


        }
    }