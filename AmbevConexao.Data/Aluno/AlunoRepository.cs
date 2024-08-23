using AmbevConexao.Domain.Aluno;
using AmbevConexao.Infraestructure.Common;

namespace AmbevConexao.Infraestructure.Aluno
{
    public class AlunoRepository : BaseRepository<AlunoEntity>, IAlunoRepository
    {
        public AlunoRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
