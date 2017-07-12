using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }


        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }


        //Asociacion Reserva 0 a muchos
        public List<ReservaDTO> Reservas { get; set; }
        //Agregacion de 1 a muchos
        public List<PedidoDTO> Pedidos { get; set; }
        public ClienteDTO()
        {
            Reservas = new List<ReservaDTO>();
            Pedidos = new List<PedidoDTO>();
        }
    }
}