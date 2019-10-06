using FarmaBotMicroService.DiagnosticoService.Domain.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.CQRS
{
    public interface IQueue
    {
        Task EnqueueAsync(QueueMessage message);
        Task<string> DequeueAsync(string queueName);
        void Enqueue(QueueMessage message);
        string Dequeue(string queueName);
    }
}
