using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AppModel
{
    public class MedicamentoDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public ItemPedidoDTO ItemPedido { get; set; }
    }
}
