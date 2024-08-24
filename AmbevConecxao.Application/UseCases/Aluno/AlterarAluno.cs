using AmbevConexao.Domain.Aluno;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Aluno;

public class AlterarAlunoCommand : IRequest<AlterarAlunoResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Email{ get; set; }

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
        var alunoEntidade = _repository.Selecionar(request.Id);

        alunoEntidade.AlterarNome(request.Nome);
        alunoEntidade.AlterarEndereco(request.Nome);
        alunoEntidade.AlterarEmail(request.Nome);

        _repository.Alterar(alunoEntidade);

        return new AlterarAlunoResponse
        {
            Aluno = alunoEntidade
        };
    }
}
