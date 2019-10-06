using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate
{
    public class Sintoma
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}
