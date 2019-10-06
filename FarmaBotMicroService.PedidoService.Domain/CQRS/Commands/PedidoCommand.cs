using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.CQRS.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Pedido Pedido { get; set; }

        public PedidoCommand(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
