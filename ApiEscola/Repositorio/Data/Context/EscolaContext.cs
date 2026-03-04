using ApiEscola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Repositorio.Data.Context
{
    public class EscolaContext : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasOne<Aluno>()
                      .WithMany()
                      .HasForeignKey(m => m.IdAluno)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Turma>()
                      .WithMany()
                      .HasForeignKey(m => m.IdTurma)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}