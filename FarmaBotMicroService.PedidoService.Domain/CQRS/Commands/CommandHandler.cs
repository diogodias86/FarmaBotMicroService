using FarmaBotMicroService.PedidoService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.CQRS.Commands
{
   public class CommandHandler
    {
        private readonly Services.PedidoService _service;

        public CommandHandler(Services.PedidoService service)
        {
            _service = service;
        }

        public void Handle(AddPedidoCommand command)
        {
            _service.AddPedido(command.Pedido);
        }

        public void Handle(UpdatePedidoCommand command)
        {
            _service.UpdatePedido(command.Pedido);
        }

        public void Handle(DeletePedidoCommand command)
        {
            _service.DeletePedido(command.Pedido.Id);
        }
    }
}
