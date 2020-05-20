using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ds.Data.Context
{
   public  class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Diario> Diarios { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<AlunosResponsavel> AlunosResponsaveis { get; set; }

        public DbSet <DisciplinaProfessor> DisciplinaProfessores { get; set; }

        public DbSet <TurmaAluno> TurmaAlunos { get; set; }

        public DbSet <TurmaDisciplina> TurmaDisciplinas { get; set; }

        public DbSet <Periodo> Periodos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EscolaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        ////protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    optionsBuilder.EnableSensitiveDataLogging();
        ////}
        ///

    }
}
