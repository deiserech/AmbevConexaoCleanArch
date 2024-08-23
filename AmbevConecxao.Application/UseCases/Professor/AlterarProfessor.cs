using AmbevConexao.Domain.Professor;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Professor;


public class AlterarProfessorCommand : IRequest<AlterarProfessorResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public AlterarProfessorCommand(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class AlterarProfessorResponse
{
    public ProfessorEntity? Professor { get; set; }
}

public sealed class AlterarProfessor : IRequestHandler<AlterarProfessorCommand, AlterarProfessorResponse>
{
    private readonly IProfessorRepository _repository;

    public AlterarProfessor(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<AlterarProfessorResponse> Handle(AlterarProfessorCommand request, CancellationToken cancellationToken)
    {
        var alunoEntidade = _repository.Selecionar(request.Id);

        alunoEntidade.AlterarNome(request.Nome);

        _repository.Alterar(alunoEntidade);

        return new AlterarProfessorResponse
        {
            Professor = alunoEntidade
        };
    }
}
