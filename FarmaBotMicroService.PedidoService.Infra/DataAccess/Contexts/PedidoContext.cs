﻿using FarmaBotMicroService.PedidoService.Domain.PedidoAggregate;
using FarmaBotMicroService.PedidoService.Infra.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Infra.DataAccess.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<ItemPedido> Itens { get; set; }

        public PedidoContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Resources.DbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicamento>()
                .HasOne(m => m.ItemPedido)
                .WithOne(i => i.Medicamento)
                .HasForeignKey<ItemPedido>(m => m.MedicamentoId);
        }
    }
}
