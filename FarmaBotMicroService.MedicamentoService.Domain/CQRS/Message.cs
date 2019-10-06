using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS
{
    public abstract class Message
    {
        public DateTime Timestamp { get; set; }
        public Message()
        {
            Timestamp = DateTime.Now;
        }
    }
}
