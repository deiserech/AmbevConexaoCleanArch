using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Matricula;
using AmbevConexao.Domain.Professor;
using System.Text.Json.Serialization;

namespace AmbevConexao.Domain.Curso
{
    public class CursoEntity : IEntity
    {
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public int Vagas { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public bool Ativo { get; private set; }
        public int? ProfessorId { get; private set; }
        [JsonIgnore]
        public ProfessorEntity? Professor { get; private set; }
        [JsonIgnore]
        public List<MatriculaEntity>? Matriculas { get; private set; }
        [JsonIgnore]
        public bool PossuiVaga => Vagas > 0;
        [JsonIgnore]
        public bool CursoEmAndamento => DataInicio != null && DataInicio >= DateTime.UtcNow;
        [JsonIgnore]
        public bool PermitidoMatricular => PossuiVaga && !CursoEmAndamento && DataInicio != null;

        public static CursoEntity NovoCurso(string titulo, string descricao)
        {
            var turma = new CursoEntity
            {
                Titulo = titulo,
                Descricao = descricao,
                Vagas = 30,
                Ativo = false
            };

            return turma;
        }

        public CursoEntity AtivarCurso(DateTime dataInicio, int idProfessor)
        {
            ProfessorId = idProfessor;
            DataInicio = dataInicio;
            Ativo = true;
            return this;
        }

        public CursoEntity DesativarCurso()
        {
            Ativo = false;
            DataFim = DateTime.UtcNow;
            return this;
        }


        public CursoEntity OcuparVaga()
        {
            Vagas--;
            return this;
        }

        public CursoEntity LiberarVaga()
        {
            Vagas++;
            return this;
        }
    }
}
