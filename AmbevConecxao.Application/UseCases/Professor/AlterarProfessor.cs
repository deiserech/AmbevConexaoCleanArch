using AmbevConexao.Domain.Professor;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Professor;


public class AlterarProfessorCommand : IRequest<AlterarProfessorResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public AlterarProfessorCommand(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
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
        alunoEntidade.AlterarEmail(request.Email);

        _repository.Alterar(alunoEntidade);

        return new AlterarProfessorResponse
        {
            Professor = alunoEntidade
        };
    }
}
