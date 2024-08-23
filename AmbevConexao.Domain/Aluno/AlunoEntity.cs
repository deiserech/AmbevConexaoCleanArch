using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.TurmaAluno;

namespace AmbevConexao.Domain.Aluno
{
    public class AlunoEntity : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public List<TurmaAlunoEntity> TurmaAluno { get; private set; }

        public static AlunoEntity NovoAluno(string nome)
        {
            var aluno = new AlunoEntity();
            aluno.Nome = nome;
            aluno.Ativo = true;
            return aluno;
        }

        public AlunoEntity AlterarNome(string novoNome)
        {
            Nome = novoNome;
            return this;
        }
    }
}
