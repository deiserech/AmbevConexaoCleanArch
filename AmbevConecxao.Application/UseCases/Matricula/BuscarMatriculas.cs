using AmbevConexao.Domain.Matricula;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Matricula;

public class BuscarMatriculaCommand : IRequest<BuscarMatriculaResponse>
{
    public int Id { get; set; }

    public BuscarMatriculaCommand(int id)
    {
        Id = id;
    }
}

public class BuscarMatriculasCommand : IRequest<BuscarMatriculasResponse>
{
}

public class BuscarMatriculasResponse
{
    public List<MatriculaEntity> Matriculas { get; set; }
}

public class BuscarMatriculaResponse
{
    public MatriculaEntity Matricula { get; set; }
}

public sealed class BuscarMatricula : IRequestHandler<BuscarMatriculaCommand, BuscarMatriculaResponse>
{
    private readonly IMatriculaRepository _repository;

    public BuscarMatricula(IMatriculaRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarMatriculaResponse> Handle(BuscarMatriculaCommand request, CancellationToken cancellationToken)
    {
        var matricula = _repository.Selecionar(request.Id);

        return new BuscarMatriculaResponse
        {
            Matricula = matricula
        };
    }
}

public sealed class BuscarMatriculas : IRequestHandler<BuscarMatriculasCommand, BuscarMatriculasResponse>
{
    private readonly IMatriculaRepository _repository;

    public BuscarMatriculas(IMatriculaRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarMatriculasResponse> Handle(BuscarMatriculasCommand request, CancellationToken cancellationToken)
    {
        var matriculas = _repository.SelecionarTudo();

        return new BuscarMatriculasResponse
        {
            Matriculas = matriculas.ToList()
        };

    }
}
