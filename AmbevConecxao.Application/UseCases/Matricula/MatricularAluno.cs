using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Common.Enums;
using AmbevConexao.Domain.Curso;
using AmbevConexao.Domain.Matricula;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Matricula;

public class MatricularAlunoCommand : IRequest<MatricularAlunoResponse>
{
    public string IdAluno { get; set; }
    public string IdCurso { get; set; }

    public MatricularAlunoCommand(string idAluno, string idCurso)
    {
        IdAluno = idAluno;
        IdCurso = idCurso;
    }
}

public class MatricularAlunoResponse
{
    public string StatusMatricula { get; set; }
}

public sealed class MatricularAluno : IRequestHandler<MatricularAlunoCommand, MatricularAlunoResponse>
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly ICursoRepository _cursoRepository;

    public MatricularAluno(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository, ICursoRepository cursoRepository)
    {
        _matriculaRepository = matriculaRepository;
        _alunoRepository = alunoRepository;
        _cursoRepository = cursoRepository;
    }

    public async Task<MatricularAlunoResponse> Handle(MatricularAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = _alunoRepository.Selecionar(int.Parse(request.IdAluno));
        var curso = _cursoRepository.Selecionar(int.Parse(request.IdCurso));

        if (curso is null || aluno is null)
        {
            return new MatricularAlunoResponse();
        }

        var matricula = MatriculaEntity.MatricularAluno(curso, aluno);
        if (matricula.Status == StatusMatricula.Ativo)
        {
            _matriculaRepository.Incluir(matricula);
        }

        var matriculas = _matriculaRepository.SelecionarTudo();

        return new MatricularAlunoResponse
        {
            StatusMatricula = matricula.DescricaoStatus
        };
    }
}
