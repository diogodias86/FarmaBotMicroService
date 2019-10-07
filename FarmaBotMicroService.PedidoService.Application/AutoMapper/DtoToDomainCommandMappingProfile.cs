using AutoMapper;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Domain.CQRS.Commands;
using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AutoMapper
{
    public class DtoToDomainCommandMappingProfile : Profile
    {
        public DtoToDomainCommandMappingProfile()
        {
            var dtoConfig = AutoMapperConfig.RegisterDtoDomainMappings();
            var mapper = dtoConfig.CreateMapper();

            CreateMap<PedidoDTO, AddPedidoCommand>()
                .ConstructUsing(a => new AddPedidoCommand(mapper.Map<PedidoDTO, Pedido>(a)));

            CreateMap<PedidoDTO, UpdatePedidoCommand>()
                .ConstructUsing(a => new UpdatePedidoCommand(mapper.Map<PedidoDTO, Pedido>(a)));

            CreateMap<PedidoDTO, DeletePedidoCommand>()
                .ConstructUsing(a => new DeletePedidoCommand(mapper.Map<PedidoDTO, Pedido>(a)));
        }
    }
}
