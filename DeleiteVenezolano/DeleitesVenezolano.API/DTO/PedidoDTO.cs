using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class PedidoDTO
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Cantidad { get; set; }

        //Enumerador
        public EstadoPedidoDTO EstadoPedido { get; set; }
        //Asociacion 1 a 1
        public EmpleadoDTO Empleado { get; set; }
        public int EmpleadoId { get; set; }
        //Agregacion 0 a muchos
        public List<PromocionDTO> Promociones { get; set; }
        public List<MenuDTO> Menus { get; set; }
        //Agregacion de 1 a 1
        public ClienteDTO Cliente { get; set; }
        public int ClienteId { get; set; }
        //Composicion de 1 a 1
        public ComprobanteDTO Comprobante { get; set; }
        public int ComprobanteId { get; set; }

        public PedidoDTO()
        {
            //Enumerador
            EstadoPedido = EstadoPedidoDTO.Activo;
            //Composicion
            Comprobante = new ComprobanteDTO();
            //Agregacion 0 a muchos
            Promociones = new List<PromocionDTO>();
            Menus = new List<MenuDTO>();
        }
        public PedidoDTO(EstadoPedidoDTO estadoPedido, List<PromocionDTO> promocion, List<MenuDTO> menu, ClienteDTO cliente)
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