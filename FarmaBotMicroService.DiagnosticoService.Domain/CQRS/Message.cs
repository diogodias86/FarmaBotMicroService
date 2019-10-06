using System;

namespace FarmaBotMicroService.DiagnosticoService.Domain.CQRS
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
