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
        private readonly Domain.Services.PedidoService _pedidoQueryService;

        public ApiAppService(IQueue queue, Domain.Services.PedidoService service)
        {
            _queue = queue;
            _pedidoQueryService = service;
        }

        //====== COMMANDS ======
        public void AddPedido(PedidoDTO pedidoDTO)
        {
            _queue.EnqueueAsync(new AddPedidoCommand(new Pedido
            {
                ClienteId = pedidoDTO.ClienteId,
                Data = pedidoDTO.Data,
                Endereco = pedidoDTO.Endereco
            }));
        }

        public void UpdatePedido(PedidoDTO pedidoDTO)
        {
            _queue.EnqueueAsync(new UpdatePedidoCommand(new Pedido
            {
                Id = pedidoDTO.Id,
                ClienteId = pedidoDTO.ClienteId,
                Endereco = pedidoDTO.Endereco,
                Data = pedidoDTO.Data
            }));
        }

        public void DeleteMedicamento(Guid id)
        {
            _queue.EnqueueAsync(new DeletePedidoCommand(new Pedido
            {
                Id = id
            }));
        }

        //====== QUERIES ======
        public PedidoDTO GetPedido(Guid id)
        {
            var pedido = _pedidoQueryService.GetPedido(id);
            return new PedidoDTO
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                Endereco = pedido.Endereco,
                Data = pedido.Data
            };
        }

        public IEnumerable<PedidoDTO> GetAllPedidos()
        {
            var pedidos = _pedidoQueryService.GetAllPedidos();

            return pedidos.Select((m) =>
                new PedidoDTO
                {
                    Id = m.Id,
                    ClienteId = m.ClienteId,
                    Endereco = m.Endereco,
                    Data = m.Data
                });
        }

        }
}
