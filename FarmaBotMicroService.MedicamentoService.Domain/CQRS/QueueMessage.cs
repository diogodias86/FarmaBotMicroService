using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS
{
    public abstract class QueueMessage : Message
    {
        public abstract string QueueName { get; }
    }
}
