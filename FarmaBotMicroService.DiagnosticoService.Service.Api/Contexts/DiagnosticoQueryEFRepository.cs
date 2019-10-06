using FarmaBotMicroService.DiagnosticoService.Application.AppModel;
using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmaBotMicroService.DiagnosticoService.Service.Api.Contexts
{
    public class DiagnosticoQueryEFRepository : IDiagnosticoQueryRepository
    {
        private readonly DiagnosticoDbContext _context;

        public DiagnosticoQueryEFRepository(DiagnosticoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Medicamento> GetMedicamentosPorSintoma(string sintomas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicamento> GetMedicamentos()
        {
            var medicamentos = _context.Medicamentos
                .Include(s => s.Sintomas)
                .ToList();

            var result = new List<Medicamento>();

            foreach (var m in medicamentos)
            {
                var medicamento = new Medicamento
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    Sintomas = m.Sintomas.Select(s => new Sintoma
                    {
                        Id = s.Id,
                        Descricao = s.Descricao
                    }).ToList()
                };

                result.Add(medicamento);
            };

            return result;
        }
    }
}
