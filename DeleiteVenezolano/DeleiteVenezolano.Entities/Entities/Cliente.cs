using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        

        //Asociacion Reserva 0 a muchos
        public List<Reserva> Reservas { get; set; }
        //Agregacion de 1 a muchos
        public List<Pedido> Pedidos { get; set; }
        public Cliente()
        {
            Reservas = new List<Reserva>();
            Pedidos = new List<Pedido>();
        }

    }
}
