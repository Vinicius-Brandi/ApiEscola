using ApiEscola.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Data.Context
{
    public class EscolaContext : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Alunos)
                .WithOne()
                .HasForeignKey(a => a.TurmaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}