using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Domain.CQRS
{
    public abstract class QueueMessage : Message
    {
        public abstract string QueueName { get; }
    }
}
