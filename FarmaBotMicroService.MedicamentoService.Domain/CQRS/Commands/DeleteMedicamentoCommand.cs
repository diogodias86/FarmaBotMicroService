using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands
{
    public class DeleteMedicamentoCommand : MedicamentoCommand
    {
        public const string ConstQueueName = "delete-medicamento-command-queue";
        public override string QueueName => ConstQueueName;

        public DeleteMedicamentoCommand(Medicamento medicamento) : base(medicamento)
        {
        }        
    }
}
