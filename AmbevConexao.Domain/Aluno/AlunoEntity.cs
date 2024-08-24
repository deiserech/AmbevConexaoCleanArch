using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Matricula;

namespace AmbevConexao.Domain.Aluno
{
    public class AlunoEntity : IEntity
    {
        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Endereco { get; private set; }
        public string? Email { get; private set; }
        public bool Ativo { get; private set; }
        public List<MatriculaEntity> Matriculas { get; private set; }

        public static AlunoEntity NovoAluno(string nome, string endereco, string email)
        {
            var aluno = new AlunoEntity();
            aluno.Nome = nome;
            aluno.Endereco = endereco;
            aluno.Email = email;
            aluno.Ativo = true;
            return aluno;
        }

        public AlunoEntity AlterarNome(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
            return this;
        }
        public AlunoEntity AlterarEndereco(string novoEndereco)
        {
            if (!string.IsNullOrWhiteSpace(novoEndereco))
            {
                Endereco = novoEndereco;
            }
            return this;
        }

        public AlunoEntity AlterarEmail(string novoEmail)
        {
            if (!string.IsNullOrWhiteSpace(novoEmail))
            {
                Email = novoEmail;
            }

            return this;
        }

        public AlunoEntity Inativar()
        {
            Ativo = false;
            return this;
        }
    }
}
