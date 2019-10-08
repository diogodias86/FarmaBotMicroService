using AutoMapper;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AutoMapper
{
   public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<ItemPedido, ItemPedidoDTO>().ReverseMap();
            CreateMap<Medicamento, MedicamentoDTO>().ReverseMap();
        }
    }
}
