using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.CQRS.Commands
{
    public class AddPedidoCommand : PedidoCommand
    {
        public const string ConstQueueName = "add-pedido-command-queue";

        public override string QueueName => ConstQueueName;

        public AddPedidoCommand(Pedido pedido) : base(pedido)
        {
        }
    }
}
