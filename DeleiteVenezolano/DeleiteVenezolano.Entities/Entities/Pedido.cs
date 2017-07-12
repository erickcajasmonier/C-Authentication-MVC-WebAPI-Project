using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Cantidad { get; set; }

        //Enumerador
        public EstadoPedido EstadoPedido { get; set; }
        //Asociacion 1 a 1
        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
        //Agregacion 0 a muchos
        public List<Promocion> Promociones { get; set; }
        public List<Menu> Menus { get; set; }
        //Agregacion de 1 a 1
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        //Composicion de 1 a 1
        public Comprobante Comprobante { get; set; }
        public int ComprobanteId { get; set; }

        public Pedido()
        {
            //Enumerador
            EstadoPedido = EstadoPedido.Activo;
            //Composicion
            Comprobante = new Comprobante();
            //Agregacion 0 a muchos
            Promociones = new List<Promocion>();
            Menus = new List<Menu>();
        }
        public Pedido(EstadoPedido estadoPedido, List<Promocion> promocion, List<Menu> menu, Cliente cliente)
        {
            //Enumerador
            EstadoPedido = estadoPedido;
            //Agregacion
            Promociones = promocion;
            Menus = menu;
            Cliente = cliente;
        }

    }
}
