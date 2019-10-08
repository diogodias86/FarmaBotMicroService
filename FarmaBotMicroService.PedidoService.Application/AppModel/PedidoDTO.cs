using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AppModel
{
   public class PedidoDTO
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public Guid ClienteId { get; set; }

        public string Endereco { get; set; }

        public List<ItemPedidoDTO> Itens { get; set; }
    }
}
