using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Domain.Services
{
    public class DiagnosticoQueryService
    {
        private readonly IDiagnosticoQueryRepository _repository;

        public DiagnosticoQueryService(IDiagnosticoQueryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Medicamento> Diagnosticar(string sintomas)
        {
            Dictionary<Guid, int> rankingMedicamentos = new Dictionary<Guid, int>();

            var sintomasList = sintomas.Split(',');

            var medicamentos = _repository.GetMedicamentos();

            foreach (var s in sintomasList)
            {
                foreach (var medicamento in medicamentos)
                {
                    if (medicamento.CobreSintoma(s))
                    {
                        if (rankingMedicamentos.TryGetValue(medicamento.Id, out int total))
                        {
                            rankingMedicamentos[medicamento.Id] = total + 1;
                        }
                        else
                        {
                            rankingMedicamentos.Add(medicamento.Id, 1);
                        }
                    }
                }
            }

            // Seleciona os 4 primeiros medicamentos que mais aparecem na lista.
            var topMedicamentos = rankingMedicamentos.OrderByDescending(p => p.Value).Take(4);

            var sugestoes = new List<Medicamento>();

            foreach (var id in topMedicamentos)
            {
                sugestoes.Add(medicamentos.Single(p => p.Id == id.Key));
            }

            return sugestoes;
        }

        public string RawString(string value)
        {
            return new string(value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
