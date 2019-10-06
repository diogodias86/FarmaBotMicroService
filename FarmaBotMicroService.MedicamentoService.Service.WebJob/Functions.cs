using FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands;
using FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Contexts;
using FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Repositories.EFCore;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FarmaBotMicroService.MedicamentoService.Service.WebJob
{
    public class Functions
    {
        private static CommandHandler _commandHandler;

        public Functions()
        {
            _commandHandler = new CommandHandler(
                new Domain.Services.MedicamentoService(
                    new MedicamentoRepository(
                        new MedicamentoContext()
                    )
                )
            );
        }

        public static void ProcessAddMedicamentoCommandQueueMessage([QueueTrigger(AddMedicamentoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<AddMedicamentoCommand>(message);
            _commandHandler.Handle(command);
        }

        public static void ProcessUpdateMedicamentoCommandQueueMessage([QueueTrigger(UpdateMedicamentoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<UpdateMedicamentoCommand>(message);
            _commandHandler.Handle(command);
        }

        public static void ProcessDeleteMedicamentoCommandQueueMessage([QueueTrigger(DeleteMedicamentoCommand.ConstQueueName)] string message, ILogger logger)
        {
            logger.LogInformation($"{message}\n");
            new Functions();
            var command = JsonConvert.DeserializeObject<DeleteMedicamentoCommand>(message);
            _commandHandler.Handle(command);
        }
    }
}
