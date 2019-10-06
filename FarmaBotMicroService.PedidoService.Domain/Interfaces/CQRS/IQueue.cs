using FarmaBotMicroService.PedidoService.Domain.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmaBotMicroService.PedidoService.Domain.Interfaces.CQRS
{
    public interface IQueue
    {
        Task EnqueueAsync(QueueMessage message);
        Task<string> DequeueAsync(string queueName);
    }
}
