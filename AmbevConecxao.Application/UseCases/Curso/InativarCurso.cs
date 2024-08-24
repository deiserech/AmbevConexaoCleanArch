using AmbevConexao.Domain.Curso;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Curso;

public class InativarCursoCommand : IRequest<InativarCursoResponse>
{
    public int Id { get; set; }

    public InativarCursoCommand(int id)
    {
        Id = id;
    }
}

public class InativarCursoResponse
{
    public CursoEntity? Curso { get; set; }
}

public sealed class InativarCurso : IRequestHandler<InativarCursoCommand, InativarCursoResponse>
{
    private readonly ICursoRepository _repository;

    public InativarCurso(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<InativarCursoResponse> Handle(InativarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = _repository.Selecionar(request.Id);
        if (curso is null)
        {
            return new InativarCursoResponse();
        }

        curso.DesativarCurso();

        _repository.Alterar(curso);

        return new InativarCursoResponse
        {
            Curso = curso
        };
    }
}
