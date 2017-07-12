using DeleiteVenezolano.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {

        private readonly DeleiteDbContext _Context;


        public IClienteRepository Clientes { get; private set; }
        public IComprobanteRepository Comprobantes { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IMenuRepository Menus { get; private set; }
        public IMesaRepository Mesas { get; private set; }
        public IPedidoRepository Pedidos { get; private set; }
        public IPromocionRepository Promociones { get; private set; }
        public IReservaRepository Reservas { get; private set; }




        public UnityOfWork()
        {

            _Context = new DeleiteDbContext();

            Clientes = new ClienteRepository(_Context);
            Comprobantes = new ComprobanteRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Menus = new MenuRepository(_Context);
            Mesas = new MesaRepository(_Context);
            Pedidos = new PedidoRepository(_Context);
            Promociones = new PromocionRepository(_Context);
            Reservas = new ReservaRepository(_Context);

        }

        /* private static UnityOfWork _Instance;
         private static readonly object _Lock = new object();
         public static UnityOfWork Instance
         {
             get
             {
                 lock (_Lock)
                 {
                     if (_Instance == null)
                     {
                         _Instance = new UnityOfWork();
                     }
                 }

                 return _Instance;
             }
         }*/

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();

        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
