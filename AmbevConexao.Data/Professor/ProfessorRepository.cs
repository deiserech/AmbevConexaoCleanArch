using AmbevConexao.Domain.Professor;
using AmbevConexao.Infraestructure.Common;

namespace AmbevConexao.Infraestructure.Professor
{
    public class ProfessorRepository : BaseRepository<ProfessorEntity>, IProfessorRepository
    {
        public ProfessorRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
