using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.CQRS.Commands
{
    public class DeletePedidoCommand : PedidoCommand
    {
        public const string ConstQueueName = "delete-pedido-command-queue";
        public override string QueueName => ConstQueueName;

        public DeletePedidoCommand(Pedido pedido) : base(pedido)
        {
        }
    }
}
