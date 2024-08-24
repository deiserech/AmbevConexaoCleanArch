using AmbevConexao.Domain.Aluno;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Aluno;

public class InativarAlunoCommand : IRequest<InativarAlunoResponse>
{
    public int Id { get; set; }

    public InativarAlunoCommand(int id)
    {
        Id = id;
    }
}

public class InativarAlunoResponse
{
    public bool Success { get; set; }
}

public sealed class InativarAluno : IRequestHandler<InativarAlunoCommand, InativarAlunoResponse>
{
    private readonly IAlunoRepository _repository;

    public InativarAluno(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<InativarAlunoResponse> Handle(InativarAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = _repository.Selecionar(request.Id);
        aluno.Inativar();
        _repository.Alterar(aluno);

        return new InativarAlunoResponse
        {
            Success = true
        };
    }
}
