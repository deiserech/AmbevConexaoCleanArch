using AmbevConexao.Domain.Professor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.Professor
{
    public class ProfessorMap : IEntityTypeConfiguration<ProfessorEntity>
    {
        public void Configure(EntityTypeBuilder<ProfessorEntity> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Banco)
               .HasColumnType("varchar(50)")
               .IsRequired(false);

            builder.Property(x => x.Agencia)
               .HasColumnType("varchar(10)");

            builder.Property(x => x.Conta)
               .HasColumnType("varchar(20)");
        }
    }
}
