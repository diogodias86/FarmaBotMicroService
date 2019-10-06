using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Domain.Interfaces.Repositories
{
    public interface IMedicamentoRepository
    {
        void Create(Medicamento medicamento);
        Medicamento Read(Guid id);
        IEnumerable<Medicamento> ReadAll();
        void Update(Medicamento medicamento);
        void Delete(Guid id);
    }
}
