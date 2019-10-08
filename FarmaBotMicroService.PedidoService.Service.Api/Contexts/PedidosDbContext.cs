using FarmaBotMicroService.PedidoService.Application.AppModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaBotMicroService.PedidoService.Service.Api.Contexts
{
    public class PedidosDbContext : DbContext
    {
        public DbSet<PedidoDTO> Pedidos { get; set; }
        public DbSet<MedicamentoDTO> Medicamentos { get; set; }
        public DbSet<ItemPedidoDTO> Itens { get; set; }

        public PedidosDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=tcp:farmabotserver.database.windows.net,1433;Initial Catalog=FarmaBotPedidoDb;Persist Security Info=False;User ID=farmabot;Password=@Infnet123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicamentoDTO>()
                .HasOne(m => m.ItemPedido)
                .WithOne(i => i.Medicamento)
                .HasForeignKey<ItemPedidoDTO>(m => m.MedicamentoId);
        }
    }
}
