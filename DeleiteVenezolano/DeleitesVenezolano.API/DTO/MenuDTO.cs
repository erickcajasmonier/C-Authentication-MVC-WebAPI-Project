using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class MenuDTO
    {
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        //Enumerador
        public TipoMenuDTO TipoMenu { get; set; }
        //Agregacion 0 a muchos
        public List<PedidoDTO> Pedidos { get; set; }

        public MenuDTO()
        {
            //Enumerador
            TipoMenu = TipoMenuDTO.NoDefinido;
            //Agregacion 0 a muchos
            Pedidos = new List<PedidoDTO>();
        }
        public MenuDTO(TipoMenuDTO tipoMenu)
        {
            //Enumerador
            TipoMenu = tipoMenu;
        }
    }
}