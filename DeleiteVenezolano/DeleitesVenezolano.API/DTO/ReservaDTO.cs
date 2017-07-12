using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class ReservaDTO
    {
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        //Asociacion de 1 a 1
        public ClienteDTO Cliente { get; set; }
        public int ClienteId { get; set; }

        //Asociacion de 1 a muchos
        public List<MesaDTO> Mesas { get; set; }
        public ReservaDTO()
        {
            Mesas = new List<MesaDTO>();
        }
    }
}