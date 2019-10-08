using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Domain.PedidoAggregate
{
    public class ItemPedido
    {
        public Guid Id { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
        public Guid MedicamentoId { get; set; }
        public Medicamento Medicamento { get; set; }
        public Pedido Pedido { get; set; }
    }
}
