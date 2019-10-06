using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;
using FarmaBotMicroService.DiagnosticoService.Domain.Interfaces.Repositories;
using FarmaBotMicroService.DiagnosticoService.Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FarmaBotMicroService.DiagnosticoService.Infra.DataAccess.Repositories.EFCore
{
    public class MedicamentoRepository : IMedicamentoCommandRepository
    {
        private readonly DiagnosticoDbContext _context;

        public MedicamentoRepository(DiagnosticoDbContext context)
        {
            this._context = context;
        }

        public void Create(Medicamento medicamento)
        {
            //_context.Medicamentos.Add(medicamento);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            //_context.Medicamentos.Remove(Read(id));
            _context.SaveChanges();
        }        

        public void Update(Medicamento medicamento)
        {
            _context.Entry(medicamento).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
