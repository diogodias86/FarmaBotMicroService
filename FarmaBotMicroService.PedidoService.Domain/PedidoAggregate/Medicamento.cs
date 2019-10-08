using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.PedidoAggregate
{
    public class Medicamento
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        
        public ItemPedido ItemPedido { get; set; }
    }
}
