using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IMesaRepository : IRepository<Mesa>
    {
        //Obtener relacion de mesas por reservas 
       // IEnumerable<Mesa> GetMesaByReserva(Reserva reserva, int pageIndex, int pageSize);

        //Obtener relacion de mesas por estado de mesa 
        //IEnumerable<Mesa> GetMesaByEstadoMesa(EstadoMesa estadoMesa);


    }
}
