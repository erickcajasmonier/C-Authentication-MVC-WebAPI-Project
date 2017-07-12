using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IComprobanteRepository : IRepository<Comprobante>
    {
        //Obtener relacion de comprobante por tipo de comprobante
         // IEnumerable<Comprobante> GetComprobanteByTipoComprobante(TipoComprobante tipoComprobante);

        //Obtener relacion de comprobante por tipo de comprobante y cliente
        //IEnumerable<Comprobante> GetComprobanteByTipoComprobanteAndCliente(TipoComprobante tipoComprobante, Cliente cliente, int pageIndex, int pageSize);
    }
}
