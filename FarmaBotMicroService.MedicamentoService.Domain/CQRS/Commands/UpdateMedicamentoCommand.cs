using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands
{
    public class UpdateMedicamentoCommand : MedicamentoCommand
    {
        public const string ConstQueueName = "add-medicamento-command-queue";

        public override string QueueName => ConstQueueName;

        public UpdateMedicamentoCommand(Medicamento medicamento) : base(medicamento)
        {
        }
    }
}
