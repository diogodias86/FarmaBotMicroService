using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using System;

namespace FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories
{
    public interface IMedicamentoCommandRepository
    {
        void Create(Medicamento medicamento);
        void Update(Medicamento medicamento);
        void Delete(Guid id);
    }
}
