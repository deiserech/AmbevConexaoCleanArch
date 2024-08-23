using AmbevConexao.Domain.Turma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.Turma
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Descricao)
               .HasColumnType("varchar(500)");

            builder.HasOne(t => t.Professor)
                .WithMany(tp => tp.Turmas)
                .HasForeignKey(i => i.IdProfessor);
        }
    }
}
