using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands
{
    public abstract class MedicamentoCommand : Command
    {
        public Medicamento Medicamento { get; set; }

        public MedicamentoCommand(Medicamento medicamento)
        {
            Medicamento = medicamento;
        }
    }
}
