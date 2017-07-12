using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IComprobanteRepository Comprobantes { get; }
        IEmpleadoRepository Empleados { get; }
        IMenuRepository Menus { get; }
        IMesaRepository Mesas { get; }
        IPedidoRepository Pedidos { get; }
        IPromocionRepository Promociones { get; }
        IReservaRepository Reservas { get; }


        int SaveChanges();

        void StateModified(object entity);

    }
}
