using AmbevConexao.Domain.Curso;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Curso;

public class BuscarCursoCommand : IRequest<BuscarCursoResponse>
{
    public int Id { get; set; }

    public BuscarCursoCommand(int id)
    {
        Id = id;
    }
}

public class BuscarCursosCommand : IRequest<BuscarCursosResponse>
{
}

public class BuscarCursosResponse
{
    public List<CursoEntity> Cursos { get; set; }
}

public class BuscarCursoResponse
{
    public CursoEntity Curso { get; set; }
}

public sealed class BuscarCurso : IRequestHandler<BuscarCursoCommand, BuscarCursoResponse>
{
    private readonly ICursoRepository _repository;

    public BuscarCurso(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarCursoResponse> Handle(BuscarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = _repository.Selecionar(request.Id);

        return new BuscarCursoResponse
        {
            Curso = curso
        };
    }
}

public sealed class BuscarCursos : IRequestHandler<BuscarCursosCommand, BuscarCursosResponse>
{
    private readonly ICursoRepository _repository;

    public BuscarCursos(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarCursosResponse> Handle(BuscarCursosCommand request, CancellationToken cancellationToken)
    {
        var cursos = _repository.SelecionarTudo();

        return new BuscarCursosResponse
        {
            Cursos = cursos.ToList()
        };
    }
}
