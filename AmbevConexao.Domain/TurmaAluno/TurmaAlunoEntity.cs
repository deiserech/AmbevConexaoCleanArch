using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Turma;

namespace AmbevConexao.Domain.TurmaAluno
{
    public class TurmaAlunoEntity : IEntity
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public AlunoEntity Aluno { get; set; }
        public int IdTurma { get; set; }
        public TurmaEntity Turma { get; set; }

        public static TurmaAlunoEntity MatricularAluno(int idAluno, int idTurma)
        {
            var matricula = new TurmaAlunoEntity();
            matricula.IdAluno = idAluno;
            matricula.IdTurma = idTurma;

            return matricula;
        }
    }
}
