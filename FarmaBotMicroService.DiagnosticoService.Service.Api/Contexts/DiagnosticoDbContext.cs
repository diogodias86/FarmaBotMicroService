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

            optionsBuilder.UseSqlServer("Server=tcp:farmabotserver.database.windows.net,1433;Initial Catalog=FarmaBotDb;Persist Security Info=False;User ID=farmabot;Password=@Infnet123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
