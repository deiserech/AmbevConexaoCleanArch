using AmbevConexao.Domain.Professor;
using AmbevConexao.Domain.Matricula;
using AmbevConexao.Domain.Common;

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
        public int? IdProfessor { get; private set; }
        public ProfessorEntity? Professor { get; private set; }
        public List<MatriculaEntity>? Matriculas { get; private set; }

        public bool PossuiVaga => Vagas > 0;

        public bool CursoEmAndamento => DataInicio != null && DataInicio >= DateTime.UtcNow;

        public bool PermitidoMatricular => PossuiVaga && !CursoEmAndamento;

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
            IdProfessor = idProfessor;
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
