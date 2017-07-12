using DeleiteVenezolano.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        //Obtener relacion de clientes por fecha de reserva 
        //IEnumerable<Cliente> GetClienteByFechaReserva(DateTime fecha);

        //Obtener relacion de clientes por pedido
       // IEnumerable<Cliente> GetClienteByPedido(Pedido pedido, int pageIndex, int pageSize);

    }
}
