using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate
{
    public class Medicamento
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public List<Sintoma> Sintomas { get; set; } = new List<Sintoma>();
    }
}
