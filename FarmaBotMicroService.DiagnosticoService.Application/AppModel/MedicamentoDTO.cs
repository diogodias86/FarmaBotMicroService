using System;
using System.Collections.Generic;

namespace FarmaBotMicroService.DiagnosticoService.Application.AppModel
{
    public class MedicamentoDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public List<SintomaDTO> Sintomas { get; set; } = new List<SintomaDTO>();
    }
}
