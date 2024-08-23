using AmbevConexao.Domain.Aluno;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Aluno;


public class ExcluirAlunoCommand : IRequest<ExcluirAlunoResponse>
{
    public int Id { get; set; }

    public ExcluirAlunoCommand(int id)
    {
        Id = id;
    }
}

public class ExcluirAlunoResponse
{
    public bool Success { get; set; }
}

public sealed class ExcluirAluno : IRequestHandler<ExcluirAlunoCommand, ExcluirAlunoResponse>
{
    private readonly IAlunoRepository _repository;

    public ExcluirAluno(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExcluirAlunoResponse> Handle(ExcluirAlunoCommand request, CancellationToken cancellationToken)
    {
        _repository.Excluir(request.Id);

        return new ExcluirAlunoResponse
        {
            Success = true
        };
    }
}
