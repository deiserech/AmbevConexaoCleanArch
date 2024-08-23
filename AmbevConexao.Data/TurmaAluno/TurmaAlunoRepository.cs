using AmbevConexao.Domain.TurmaAluno;
using AmbevConexao.Infraestructure.Common;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Infraestructure.TurmaAluno
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno>, ITurmaAlunoRepository
    {
        public TurmaAlunoRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<TurmaAluno> SelecionarTudoCompleto()
        {
            var t = _contexto.TurmaAluno
                .Include(x => x.Aluno)
                .Include(x => x.Turma);
            //.ThenInclude(x => x.Professor)
            //.ToList();

            return t.ToList();
        }
    }
}
