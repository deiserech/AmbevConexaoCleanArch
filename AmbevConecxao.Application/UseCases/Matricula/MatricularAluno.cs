using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Curso;
using AmbevConexao.Domain.Matricula;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Matricula;

public class MatricularAlunoCommand : IRequest<MatricularAlunoResponse>
{
    public int IdAluno { get; set; }
    public int IdCurso { get; set; }

    public MatricularAlunoCommand(int idAluno, int idMatricula)
    {
        IdAluno = idAluno;
        IdCurso = idMatricula;
    }
}

public class MatricularAlunoResponse
{
    public List<MatriculaEntity> Matriculas { get; set; }
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
        var response = new MatricularAlunoResponse();

        var aluno = _alunoRepository.Selecionar(request.IdAluno);
        var curso = _cursoRepository.Selecionar(request.IdCurso);

        if (curso is null || aluno is null)
        {
            return response;
        }

        var matricula = MatriculaEntity.MatricularAluno(curso, aluno);
        _matriculaRepository.Incluir(matricula);

        var matriculas = _matriculaRepository.SelecionarTudo();

        response.Matriculas = matriculas;
        return response;
    }
}
