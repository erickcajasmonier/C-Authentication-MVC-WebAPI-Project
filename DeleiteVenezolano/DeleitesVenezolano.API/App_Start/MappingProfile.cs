using AutoMapper;
using DeleitesVenezolano.API.DTO;
using DeleiteVenezolano.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleitesVenezolano.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Comprobante, ComprobanteDTO>();
            CreateMap<ComprobanteDTO, Comprobante>();

            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<EmpleadoDTO, Empleado>();

            CreateMap<Menu,MenuDTO>();
            CreateMap<MenuDTO, Menu>();

            CreateMap<Mesa, MesaDTO>();
            CreateMap<MesaDTO,Mesa>();

            CreateMap<Pedido, PedidoDTO>();
            CreateMap<PedidoDTO,Pedido>();

            CreateMap<Promocion, PromocionDTO>();
            CreateMap<PromocionDTO, Promocion>();

            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaDTO, Reserva>();


        }
    }
}