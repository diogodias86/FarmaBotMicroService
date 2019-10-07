using FarmaBotMicroService.MedicamentoService.Domain.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmaBotMicroService.MedicamentoService.Domain.Interfaces.CQRS
{
    public interface IQueue
    {
        Task EnqueueAsync(QueueMessage message);
        Task<string> DequeueAsync(string queueName);
    }
}
