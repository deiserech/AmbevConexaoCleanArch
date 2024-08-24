using AmbevConexao.Domain.Curso;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Curso;

public class AdicionarCursoCommand : IRequest<AdicionarCursoResponse>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public AdicionarCursoCommand(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
    }
}

public class AdicionarCursoResponse
{
    public List<CursoEntity> Cursos { get; set; }
}

public sealed class AdicionarCurso : IRequestHandler<AdicionarCursoCommand, AdicionarCursoResponse>
{
    private readonly ICursoRepository _repository;

    public AdicionarCurso(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdicionarCursoResponse> Handle(AdicionarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = CursoEntity.NovoCurso(request.Titulo, request.Descricao);

        _repository.Incluir(curso);

        var result = _repository.SelecionarTudo();

        return new AdicionarCursoResponse
        {
            Cursos = result
        };
    }
}
