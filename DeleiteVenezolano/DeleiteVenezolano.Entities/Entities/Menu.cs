using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        //Enumerador
        public TipoMenu TipoMenu { get; set; }
        //Agregacion 0 a muchos
        public List<Pedido> Pedidos { get; set; }

        public Menu()
        {
            //Enumerador
            TipoMenu = TipoMenu.NoDefinido;
            //Agregacion 0 a muchos
            Pedidos = new List<Pedido>();
        }
        public Menu(TipoMenu tipoMenu)
        {
            //Enumerador
            TipoMenu = tipoMenu;
        }

    }
}
