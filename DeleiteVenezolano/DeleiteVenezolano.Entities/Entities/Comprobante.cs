using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.Entities
{
    public class Comprobante
    {
        public int ComprobanteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Direccion { get; set; }
        public int NumDocumento { get; set; }
        public double Igv { get; set; }
        public TipoComprobante TipoComprobante { get; set; }

        public Comprobante()
        {
            TipoComprobante = TipoComprobante.NoDefinido;
        }
        public Comprobante(TipoComprobante tipoComprobante)
        {
            TipoComprobante = tipoComprobante;
        }
        //Composicion 1 a 1
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
