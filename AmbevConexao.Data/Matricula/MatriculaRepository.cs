using AmbevConexao.Domain.Matricula;
using AmbevConexao.Infraestructure.Common;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Infraestructure.Matricula
{
    public class MatriculaRepository : BaseRepository<MatriculaEntity>, IMatriculaRepository
    {
        public MatriculaRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<MatriculaEntity> SelecionarTudoCompleto()
        {
            var t = _contexto.Matricula
                .Include(x => x.Aluno)
                .Include(x => x.Curso);

            return t.ToList();
        }
    }
}
