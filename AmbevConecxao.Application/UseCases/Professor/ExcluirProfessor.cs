using AmbevConexao.Domain.Professor;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Professor;


public class ExcluirProfessorCommand : IRequest<ExcluirProfessorResponse>
{
    public int Id { get; set; }

    public ExcluirProfessorCommand(int id)
    {
        Id = id;
    }
}

public class ExcluirProfessorResponse
{
    public bool Success { get; set; }
}

public sealed class ExcluirProfessor : IRequestHandler<ExcluirProfessorCommand, ExcluirProfessorResponse>
{
    private readonly IProfessorRepository _repository;

    public ExcluirProfessor(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExcluirProfessorResponse> Handle(ExcluirProfessorCommand request, CancellationToken cancellationToken)
    {
        _repository.Excluir(request.Id);

        return new ExcluirProfessorResponse
        {
            Success = true
        };
    }
}
