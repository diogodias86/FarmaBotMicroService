using FarmaBotMicroService.PedidoService.Domain.CQRS.Commands;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Contexts;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Repositories.EFCore;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FarmaBotMicroService.PedidoService.Service.WebJob
{
  public class Functions
    {
        private static CommandHandler _commandHandler;

        public Functions()
        {
            _commandHandler = new CommandHandler(
                new Domain.Services.PedidoService(
                    new PedidoRepository(
                        new PedidoContext()
                    )
                )
            );
        }

        public static void ProcessAddMedicamentoCommandQueueMessage([QueueTrigger(AddPedidoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<AddPedidoCommand>(message);
            _commandHandler.Handle(command);
        }

        public static void ProcessUpdateMedicamentoCommandQueueMessage([QueueTrigger(UpdatePedidoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<UpdatePedidoCommand>(message);
            _commandHandler.Handle(command);
        }

        public static void ProcessDeleteMedicamentoCommandQueueMessage([QueueTrigger(DeletePedidoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<DeletePedidoCommand>(message);
            _commandHandler.Handle(command);
        }
    }
}
