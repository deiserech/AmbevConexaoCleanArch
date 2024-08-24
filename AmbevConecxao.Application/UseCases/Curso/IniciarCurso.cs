using AmbevConexao.Domain.Curso;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Curso;

public class IniciarCursoCommand : IRequest<IniciarCursoResponse>
{
    public int Id { get; set; }
    public int IdProfessor { get; set; }
    public DateTime DataInicio { get; set; }

    public IniciarCursoCommand(int id, int idProfessor, DateTime dataInicio)
    {
        Id = id;
        IdProfessor = idProfessor;
        DataInicio = dataInicio;
    }
}

public class IniciarCursoResponse
{
    public CursoEntity? Curso { get; set; }
}

public sealed class IniciarCurso : IRequestHandler<IniciarCursoCommand, IniciarCursoResponse>
{
    private readonly ICursoRepository _repository;

    public IniciarCurso(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IniciarCursoResponse> Handle(IniciarCursoCommand request, CancellationToken cancellationToken)
    {
        var cursoEntidade = _repository.Selecionar(request.Id);

        cursoEntidade.AtivarCurso(request.DataInicio, request.IdProfessor);

        _repository.Alterar(cursoEntidade);

        return new IniciarCursoResponse
        {
            Curso = cursoEntidade
        };
    }
}
