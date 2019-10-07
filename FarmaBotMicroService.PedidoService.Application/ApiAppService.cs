using AutoMapper;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Domain.CQRS.Commands;
using FarmaBotMicroService.PedidoService.Domain.Interfaces.CQRS;
using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application
{
    public class ApiAppService
    {
        private readonly IQueue _queue;
        private readonly IMapper _mapper;
        private readonly Domain.Services.PedidoService _pedidoQueryService;

        public ApiAppService(IQueue queue, IMapper mapper, Domain.Services.PedidoService service)
        {
            _queue = queue;
            _mapper = mapper;
            _pedidoQueryService = service;
        }

        //====== COMMANDS ======
        public void AddPedido(PedidoDTO pedidoDTO)
        {
            var command = _mapper.Map<AddPedidoCommand>(pedidoDTO);
            _queue.EnqueueAsync(command);

        }

        public void UpdatePedido(PedidoDTO pedidoDTO)
        {
            var command = _mapper.Map<UpdatePedidoCommand>(pedidoDTO);
            _queue.EnqueueAsync(command);
        }

        public void DeletePedido(Guid id)
        {
            var command = _mapper.Map<DeletePedidoCommand>(id);
            _queue.EnqueueAsync(command);
        }

        //====== QUERIES ======
        public PedidoDTO GetPedido(Guid id)
        {
            var pedido = _pedidoQueryService.GetPedido(id);
            var pedidoDTO = _mapper.Map<PedidoDTO>(pedido);
            return pedidoDTO;

        }

        public IEnumerable<PedidoDTO> GetAllPedidos()
        {
            var pedidos = _pedidoQueryService.GetAllPedidos();
            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);

        }

    }
}
