using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate
{
    public class Medicamento
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public List<Sintoma> Sintomas { get; set; } = new List<Sintoma>();

        public bool CobreSintoma(string sintoma)
        {
            var _sintomas = Sintomas.Select(s => s.Descricao).ToList();

            foreach (var desc in _sintomas)
            {
                if (desc.Contains(sintoma))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
