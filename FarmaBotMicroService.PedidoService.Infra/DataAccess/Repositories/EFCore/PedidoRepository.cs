using FarmaBotMicroService.PedidoService.Domain.Interfaces.Repositories;
using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Infra.DataAccess.Repositories.EFCore
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            this._context = context;
        }

        public void Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Pedidos.Remove(Read(id));
            _context.SaveChanges();
        }

        public Pedido Read(Guid id)
        {
            return _context.Pedidos.Find(id);
        }

        public IEnumerable<Pedido> ReadAll()
        {
            return _context.Pedidos;
        }

        public void Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }
    }
}
