using AmbevConecxao.Application.UseCases.Curso;
using AmbevConexao.Domain.Aluno;
using MediatR;
using System.Text.Json.Serialization;

namespace AmbevConecxao.Application.UseCases.Aluno;

public class AlterarAlunoCommand : IRequest<AlterarAlunoResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Email{ get; set; }

    public AlterarAlunoCommand(int id, string nome, string endereco, string email)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Email = email;
    }
}

public class AlterarAlunoResponse
{
    public AlunoEntity? Aluno { get; set; }
}

public sealed class AlterarAluno : IRequestHandler<AlterarAlunoCommand, AlterarAlunoResponse>
{
    private readonly IAlunoRepository _repository;

    public AlterarAluno(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AlterarAlunoResponse> Handle(AlterarAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = _repository.Selecionar(request.Id);
        if (aluno is null)
            return new AlterarAlunoResponse();


        aluno.AlterarNome(request.Nome);
        aluno.AlterarEndereco(request.Endereco);
        aluno.AlterarEmail(request.Email);

        _repository.Alterar(aluno);

        return new AlterarAlunoResponse
        {
            Aluno = aluno
        };
    }
}
