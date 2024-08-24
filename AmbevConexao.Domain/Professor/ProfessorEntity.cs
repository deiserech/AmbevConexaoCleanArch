using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Curso;
using System.Text.Json.Serialization;

namespace AmbevConexao.Domain.Professor
{
    public class ProfessorEntity : IEntity
    {
        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        [JsonIgnore]
        public List<CursoEntity> Cursos { get; set; } = new List<CursoEntity>();

        public static ProfessorEntity NovoProfessor(string nome, string email)
        {
            var professor = new ProfessorEntity
            {
                Nome = nome,
                Email = email
            };

            return professor;
        }

        public ProfessorEntity AlterarNome(string novoNome)
        {
            if (novoNome is not null)
            {
                Nome = novoNome;
            }
            return this;
        }

        public ProfessorEntity AlterarEmail(string novoEmail)
        {
            if (novoEmail is not null)
            {
                Email = novoEmail;
            }
            return this;
        }
    }
}
