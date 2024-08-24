using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Curso;
using AmbevConexao.Domain.Matricula;
using AmbevConexao.Domain.Professor;
using AmbevConexao.Infraestructure.Aluno;
using AmbevConexao.Infraestructure.Curso;
using AmbevConexao.Infraestructure.Matricula;
using AmbevConexao.Infraestructure.Professor;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Infraestructure.Common
{
    public class Contexto : DbContext
    {
        public DbSet<AlunoEntity> Aluno { get; set; }
        public DbSet<ProfessorEntity> Professor { get; set; }
        public DbSet<CursoEntity> Curso { get; set; }
        public DbSet<MatriculaEntity> Matricula { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
