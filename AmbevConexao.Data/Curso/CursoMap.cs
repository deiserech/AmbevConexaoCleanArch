using AmbevConexao.Domain.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmbevConexao.Infraestructure.Curso;

public class CursoMap : IEntityTypeConfiguration<CursoEntity>
{
    public void Configure(EntityTypeBuilder<CursoEntity> builder)
    {
        builder.ToTable("Curso");

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Titulo)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Descricao)
           .HasColumnType("varchar(200)")
           .IsRequired();

        builder.HasOne(curso => curso.Professor)
            .WithMany(professor => professor.Cursos);

        builder.HasMany(curso => curso.Matriculas)
            .WithOne(matricula => matricula.Curso);
    }
}