using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Mesa
    {
        public int MesaId { get; set; }
        public int Numero { get; set; }
        public int MaxPersonas { get; set; }

        //Enumerador
        public EstadoMesa EstadoMesa { get; set; }
        public Mesa()
        {
            EstadoMesa = EstadoMesa.Desocupado;
        }
        public Mesa(EstadoMesa estadoMesa)
        {
            EstadoMesa = estadoMesa;
        }

        //Asociacion de 1 a 1
        public Reserva Reserva { get; set; }
        public int ReservaId { get; set; }
    }
}
