using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FecInicio { get; set; }

        //Enumerador
        public TipoEmpleado TipoEmpleado { get; set; }
        //Asociacion de 1 a muchos
        public List<Pedido> Pedidos { get; set; }

        public Empleado()
        {
            //Enumerador
            TipoEmpleado = TipoEmpleado.NoDefinido;
            //Asociacion de 1 a muchos
            Pedidos = new List<Pedido>();
        }
        public Empleado(TipoEmpleado tipoEmpleado)
        {
            //Enumerador
            TipoEmpleado = tipoEmpleado;
        }

    }
}
