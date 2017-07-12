using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        //Asociacion de 1 a 1
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        //Asociacion de 1 a muchos
        public List<Mesa> Mesas { get; set; }
        public Reserva()
        {
            Mesas = new List<Mesa>();
        }
    }
}
