using FarmaBotMicroService.MedicamentoService.Domain.Interfaces.Repositories;
using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Contexts;
using System;
using System.Collections.Generic;

namespace FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Repositories.EFCore
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly MedicamentoContext _context;

        public MedicamentoRepository(MedicamentoContext context)
        {
            this._context = context;
        }

        public void Create(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Medicamentos.Remove(Read(id));
            _context.SaveChanges();
        }

        public Medicamento Read(Guid id)
        {
            return _context.Medicamentos.Find(id);
        }

        public IEnumerable<Medicamento> ReadAll()
        {
            return _context.Medicamentos;
        }

        public void Update(Medicamento medicamento)
        {
            _context.Medicamentos.Update(medicamento);
            _context.SaveChanges();
        }
    }
}
