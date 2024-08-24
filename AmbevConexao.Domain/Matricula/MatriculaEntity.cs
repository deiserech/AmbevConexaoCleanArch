using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Common.Enums;
using AmbevConexao.Domain.Curso;

namespace AmbevConexao.Domain.Matricula
{
    public class MatriculaEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public StatusMatricula Status { get; set; }
        public string DescricaoStatus { get; set; }
        public int IdAluno { get; set; }
        public AlunoEntity Aluno { get; set; }
        public int IdCurso { get; set; }
        public CursoEntity Curso { get; set; }

        public static MatriculaEntity? MatricularAluno(CursoEntity curso, AlunoEntity aluno)
        {
            var permitido = aluno.Ativo && curso.PermitidoMatricular;
            var descricaoStatus = ObterDescricaoStatus(curso, aluno);

            var matricula = new MatriculaEntity
            {
                IdAluno = aluno.Id,
                IdCurso = curso.Id,
                DataMatricula = DateTime.UtcNow,
                Status = permitido ? StatusMatricula.Ativo : StatusMatricula.Cancelada,
                DescricaoStatus = descricaoStatus,
            };

            return matricula;
        }

        public static string ObterDescricaoStatus(CursoEntity curso, AlunoEntity aluno)
        {
            if (!aluno.Ativo)
            {
                return "Matrícula não permitida. Aluno Inativo.";
            }

            if (!curso.PossuiVaga)
            {
                return "Matrícula não permitida.Curso não possui vaga.";
            }

            if (curso.CursoEmAndamento)
            {
                return "Matrícula não permitida.Curso já está em andamento.";
            }

            return "Matrícula efetivada.";
        }

        public MatriculaEntity Inativar()
        {
            Status = StatusMatricula.Inativo;
            return this;
        }
    }
}
