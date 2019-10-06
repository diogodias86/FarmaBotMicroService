using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Application.AppModel
{
    public class SintomaDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public MedicamentoDTO Medicamento { get; set; }
    }
}
