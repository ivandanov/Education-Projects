[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Teleimot.WepApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Teleimot.WepApi.App_Start.NinjectWebCommon), "Stop")]

namespace Teleimot.WepApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Teleimot.Data;
    using Teleimot.Data.Repositories;
    using Teleimot.DataServices;
    using Teleimot.DataServices.Contracts;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<TeleimotDbContext>().ToSelf();
            kernel.Bind<ITeleimotData>().To<TeleimotData>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind<IRealEstatesDataService>().To<RealEstatesDataService>();
            kernel.Bind<ICommentsDataService>().To<CommentsDataService>();
            kernel.Bind<IUserDataService>().To<UserDataService>();
        }        
    }
}
