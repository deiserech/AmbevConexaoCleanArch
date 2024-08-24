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
        var cursoEntidade = _repository.Selecionar(request.Id);

        cursoEntidade.DesativarCurso();

        _repository.Alterar(cursoEntidade);

        return new InativarCursoResponse
        {
            Curso = cursoEntidade
        };
    }
}
