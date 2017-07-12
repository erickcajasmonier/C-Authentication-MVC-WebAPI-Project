using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class EmpleadoDTO
    {
        public int EmpleadoId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FecInicio { get; set; }

        //Enumerador
        public TipoEmpleadoDTO TipoEmpleado { get; set; }
        //Asociacion de 1 a muchos
        public List<PedidoDTO> Pedidos { get; set; }

        public EmpleadoDTO()
        {
            //Enumerador
            TipoEmpleado = TipoEmpleadoDTO.NoDefinido;
            //Asociacion de 1 a muchos
            Pedidos = new List<PedidoDTO>();
        }
        public EmpleadoDTO(TipoEmpleadoDTO tipoEmpleado)
        {
            //Enumerador
            TipoEmpleado = tipoEmpleado;
        }

    }
}