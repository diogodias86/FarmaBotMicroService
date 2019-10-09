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

            optionsBuilder.UseSqlServer("STRING DE CONEXÃO");
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
