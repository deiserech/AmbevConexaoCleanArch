using AmbevConecxao.Application.UseCases.Matricula;
using AmbevConexao.Domain.Professor;
using MediatR;
using System.Text.Json.Serialization;

namespace AmbevConecxao.Application.UseCases.Professor;


public class AlterarProfessorCommand : IRequest<AlterarProfessorResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }

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
        var professor = _repository.Selecionar(request.Id);
        if (professor is null)
        {
            return new AlterarProfessorResponse();
        }

        professor.AlterarNome(request.Nome);
        professor.AlterarEmail(request.Email);

        _repository.Alterar(professor);

        return new AlterarProfessorResponse
        {
            Professor = professor
        };
    }
}
