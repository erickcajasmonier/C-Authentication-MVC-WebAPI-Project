using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.DTO
{
    public class ComprobanteDTO
    {
        public int ComprobanteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Direccion { get; set; }
        public int NumDocumento { get; set; }
        public double Igv { get; set; }
        public TipoComprobanteDTO TipoComprobante { get; set; }

        public ComprobanteDTO()
        {
            TipoComprobante = TipoComprobanteDTO.NoDefinido;
        }
        public ComprobanteDTO(TipoComprobanteDTO tipoComprobante)
        {
            TipoComprobante = tipoComprobante;
        }
        //Composicion 1 a 1
        public PedidoDTO Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}