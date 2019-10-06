using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        void Create(Pedido pedido);
        Pedido Read(Guid id);
        IEnumerable<Pedido> ReadAll();
        void Update(Pedido pedido);
        void Delete(Guid id);
    }
}
