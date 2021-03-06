[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DeleiteVenezolano.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DeleiteVenezolano.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace DeleiteVenezolano.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DeleiteVenezolano.Entities.IRepositories;
    using DeleiteVenezolano.Persistence.Repositories;
    using DeleiteVenezolano.Persistence;

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
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();

            kernel.Bind<DeleiteDbContext>().To<DeleiteDbContext>();

           
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();
            kernel.Bind<IMesaRepository>().To<MesaRepository>();
            kernel.Bind<IComprobanteRepository>().To<ComprobanteRepository>();
            kernel.Bind<IPedidoRepository>().To<PedidoRepository>();
            kernel.Bind<IPromocionRepository>().To<PromocionRepository>();
            kernel.Bind<IReservaRepository>().To<ReservaRepository>();
        }        
    }
}
