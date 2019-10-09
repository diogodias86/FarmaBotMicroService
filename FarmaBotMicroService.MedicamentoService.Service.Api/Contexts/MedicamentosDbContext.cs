using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaBotMicroService.MedicamentoService.Service.Api.Contexts
{
    public class MedicamentosDbContext : DbContext
    {
        public DbSet<MedicamentoDTO> Medicamentos { get; set; }
        public DbSet<SintomaDTO> Sintomas { get; set; }

        public MedicamentosDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("STRING DE CONEXÃO");
        }
    }
}
