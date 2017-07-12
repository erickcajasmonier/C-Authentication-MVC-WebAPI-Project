using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class MesaDTO
    {
        public int MesaId { get; set; }
        public int Numero { get; set; }
        public int MaxPersonas { get; set; }

        //Enumerador
        public EstadoMesaDTO EstadoMesa { get; set; }
        public MesaDTO()
        {
            EstadoMesa = EstadoMesaDTO.Desocupado;
        }
        public MesaDTO(EstadoMesaDTO estadoMesa)
        {
            EstadoMesa = estadoMesa;
        }

        //Asociacion de 1 a 1
        public ReservaDTO Reserva { get; set; }
        public int ReservaId { get; set; }
    }
}