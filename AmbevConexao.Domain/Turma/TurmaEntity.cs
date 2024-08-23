using AmbevConexao.Domain.Professor;
using AmbevConexao.Domain.TurmaAluno;

namespace AmbevConexao.Domain.Turma
{
    public class TurmaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public int IdProfessor { get; set; }
        public ProfessorEntity Professor { get; set; }

        public List<TurmaAlunoEntity> TurmaAluno { get; set; }

        public static TurmaEntity NovaTurma(string nome, int idProfessor)
        {
            var turma = new TurmaEntity();
            turma.Nome = nome;
            turma.IdProfessor = idProfessor;

            return turma;
        }

    }
}
