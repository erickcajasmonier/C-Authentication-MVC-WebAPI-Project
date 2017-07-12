using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        //Obtener relacion de pedido por estado de pedido
      //  IEnumerable<Pedido> GetPedidoByEstadoPedido(EstadoPedido estadoPedido);

        //Obtener relacion de pedido por estado de pedido y cliente
        //IEnumerable<Pedido> GetPedidoByEstadoPedidoAndCliente(EstadoPedido estadoPedido, Cliente cliente);
    }
}
