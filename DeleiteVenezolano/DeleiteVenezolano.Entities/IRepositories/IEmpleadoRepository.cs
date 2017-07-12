using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        //Obtener relacion de empleado por tipo de empleado
       // IEnumerable<Empleado> GetEmpleadoByTipoEmpleado(TipoEmpleado tipoEmpleado);
    }
}
