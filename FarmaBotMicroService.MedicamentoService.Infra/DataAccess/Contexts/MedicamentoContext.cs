using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using FarmaBotMicroService.MedicamentoService.Infra.Properties;
using Microsoft.EntityFrameworkCore;

namespace FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Contexts
{
    public class MedicamentoContext : DbContext
    {
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }

        public MedicamentoContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Resources.DbConnectionString);
        }
    }
}
