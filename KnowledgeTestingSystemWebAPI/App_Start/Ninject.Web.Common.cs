[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KnowledgeTestingSystemWebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KnowledgeTestingSystemWebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace KnowledgeTestingSystemWebAPI.App_Start
{
    using DAL.Interfaces;
    using DAL.Infrastructure;
    using DAL.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using DAL.AutoMapper;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<ITestService>().To<TestService>();
            List<INinjectModule> collection = new List<INinjectModule>();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            collection.Add(serviceModule);
            kernel.Load(collection);
        }
    }
}