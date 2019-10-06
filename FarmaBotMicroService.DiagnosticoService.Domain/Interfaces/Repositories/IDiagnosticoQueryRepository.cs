using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories
{
    public interface IDiagnosticoQueryRepository
    {
        IEnumerable<Medicamento> GetMedicamentosPorSintoma(string sintomas);
        IEnumerable<Medicamento> GetMedicamentos();
    }
}
