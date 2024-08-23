using AmbevConexao.Domain.Aluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.Aluno
{
    internal class AlunoMap : IEntityTypeConfiguration<AlunoEntity>
    {
        public void Configure(EntityTypeBuilder<AlunoEntity> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();
        }
    }
}
