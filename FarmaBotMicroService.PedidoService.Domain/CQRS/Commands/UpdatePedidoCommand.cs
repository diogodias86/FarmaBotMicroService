using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.CQRS.Commands
{
    public class UpdatePedidoCommand : PedidoCommand
    {
        public const string ConstQueueName = "update-pedido-command-queue";

        public override string QueueName => ConstQueueName;

        public UpdatePedidoCommand(Pedido pedido) : base(pedido)
        {
        }
    }
}
