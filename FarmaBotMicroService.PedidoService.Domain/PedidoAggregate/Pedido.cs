using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.PedidoAggregate
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public Guid ClienteId { get; set; }

        public string Endereco { get; set; }

        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}
