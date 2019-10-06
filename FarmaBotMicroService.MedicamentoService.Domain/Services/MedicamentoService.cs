using FarmaBotMicroService.MedicamentoService.Domain.Interfaces.Repositories;
using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;

namespace FarmaBotMicroService.MedicamentoService.Domain.Services
{
    public class MedicamentoService
    {
        private readonly IMedicamentoRepository _repository;

        public MedicamentoService(IMedicamentoRepository repository)
        {
            this._repository = repository;
        }

        public void AddMedicamento(Medicamento medicamento)
        {
            _repository.Create(medicamento);
        }

        public void UpdateMedicamento(Medicamento medicamento)
        {
            _repository.Update(medicamento);
        }

        public void DeleteMedicamento(Guid id)
        {
            _repository.Delete(id);
        }

        public Medicamento GetMedicamento(Guid id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<Medicamento> GetAllMedicamentos()
        {
            return _repository.ReadAll();
        }
    }
}
