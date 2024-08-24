using AmbevConexao.Domain.Curso;
using AmbevConexao.Domain.Turma;
using AmbevConexao.Infraestructure.Common;

namespace AmbevConexao.Infraestructure.Curso;

public sealed class CursoRepository(Contexto contexto) : BaseRepository<CursoEntity>(contexto), ICursoRepository
{
}
