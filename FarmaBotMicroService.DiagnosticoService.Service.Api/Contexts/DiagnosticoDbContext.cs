using FarmaBotMicroService.DiagnosticoService.Application.AppModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaBotMicroService.DiagnosticoService.Service.Api.Contexts
{
    public class DiagnosticoDbContext : DbContext
    {
        public DbSet<MedicamentoDTO> Medicamentos { get; set; }
        public DbSet<SintomaDTO> Sintomas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("STRING DE CONEXÃO");
        }
    }
}
