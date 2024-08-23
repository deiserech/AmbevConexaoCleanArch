using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.TurmaAluno
{
    public class TurmaAlunoMap : IEntityTypeConfiguration<Domain.TurmaAluno.TurmaAlunoEntity>
    {
        public void Configure(EntityTypeBuilder<Domain.TurmaAluno.TurmaAlunoEntity> builder)
        {
            builder.ToTable("TurmaAluno");

            builder.HasKey(x => new { x.IdTurma, x.IdAluno });

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.TurmaAluno)
                .HasForeignKey(x => x.IdTurma);

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.TurmaAluno)
                .HasForeignKey(x => x.IdAluno);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

        }
    }
}
