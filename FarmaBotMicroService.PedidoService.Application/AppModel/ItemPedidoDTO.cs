using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AppModel
{
    public class ItemPedidoDTO
    {
        public Guid Id { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
        public Guid MedicamentoId { get; set; }
        public MedicamentoDTO Medicamento { get; set; }
        public PedidoDTO Pedido { get; set; }
    }
}
