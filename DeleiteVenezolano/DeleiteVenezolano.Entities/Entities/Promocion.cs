using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Promocion
    {
        public int PromocionId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        //Agregacion 0 a muchos
        public List<Pedido> Pedidos { get; set; }
        public Promocion()
        {
            //Agregacion 0 a muchos
            Pedidos = new List<Pedido>();
        }

    }
}
