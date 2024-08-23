using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Professor;
using AmbevConexao.Domain.Turma;
using AmbevConexao.Domain.TurmaAluno;
using AmbevConexao.Infraestructure.Aluno;
using AmbevConexao.Infraestructure.Professor;
using AmbevConexao.Infraestructure.Turma;
using AmbevConexao.Infraestructure.TurmaAluno;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Infraestructure.Common
{
    public class Contexto : DbContext
    {
        public DbSet<AlunoEntity> Aluno { get; set; }
        public DbSet<ProfessorEntity> Professor { get; set; }
        public DbSet<TurmaEntity> Turma { get; set; }
        public DbSet<TurmaAlunoEntity> TurmaAluno { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
