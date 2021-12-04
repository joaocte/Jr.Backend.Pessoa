﻿using Jr.Backend.Pessoa.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Jr.Backend.Pessoa.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Entity.Pessoa> Pessoas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().HasOne(x => x.Pessoa)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.PessoaId);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JrPessoa;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}