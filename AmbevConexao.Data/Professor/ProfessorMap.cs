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

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasMany(Professor => Professor.Cursos)
                .WithOne(curso => curso.Professor);
        }
    }
}
