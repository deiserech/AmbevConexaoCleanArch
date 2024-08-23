using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Turma;

namespace AmbevConexao.Domain.Professor
{
    public class ProfessorEntity : IEntity
    {
        public int Id { get; set; }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public TurnoEnum Turno { get; private set; }
        public string? Banco { get; private set; }
        public string? Agencia { get; private set; }
        public string? Conta { get; private set; }
        public List<TurmaEntity> Turmas { get; set; } = new List<TurmaEntity>();

        public static ProfessorEntity NovoProfessor(string nome, string email, TurnoEnum turno)
        {
            var prof = new ProfessorEntity();
            prof.Nome = nome;
            prof.Email = email;
            prof.Turno = turno;

            return prof;
        }

        public ProfessorEntity AlterarNome(string novoNome)
        {
            Nome = novoNome;
            return this;
        }
    }
}
