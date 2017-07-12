using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class PromocionDTO
    {
        public int PromocionId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        //Agregacion 0 a muchos
        public List<PedidoDTO> Pedidos { get; set; }
        public PromocionDTO()
        {
            //Agregacion 0 a muchos
            Pedidos = new List<PedidoDTO>();
        }
    }
}