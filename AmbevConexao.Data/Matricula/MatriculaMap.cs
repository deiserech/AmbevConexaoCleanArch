using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.Matricula
{
    public class MatriculaMap : IEntityTypeConfiguration<Domain.Matricula.MatriculaEntity>
    {
        public void Configure(EntityTypeBuilder<Domain.Matricula.MatriculaEntity> builder)
        {
            builder.ToTable("Matricula");

            builder.HasKey(x => new { x.CursoId, x.AlunoId });
            
            builder.HasOne(x => x.Curso)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.CursoId);

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.AlunoId);
        }
    }
}
