using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Infra.DataAccess.Repositories
{
    public class DiagnosticoQueryRepository : IDiagnosticoQueryRepository
    {
        public IEnumerable<Medicamento> GetMedicamentos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicamento> GetMedicamentosPorSintoma(string sintomas)
        {
            throw new NotImplementedException();
        }
    }
}
