using FarmaBotMicroService.PedidoService.Domain.Interfaces.Repositories;
using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.Services
{
   public class PedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            this._repository = repository;
        }

        public void AddPedido(Pedido pedido)
        {
            _repository.Create(pedido);
        }

        public void UpdatePedido(Pedido pedido)
        {
            _repository.Update(pedido);
        }

        public void DeletePedido(Guid id)
        {
            _repository.Delete(id);
        }

        public Pedido GetPedido(Guid id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
            return _repository.ReadAll();
        }
    }
}
