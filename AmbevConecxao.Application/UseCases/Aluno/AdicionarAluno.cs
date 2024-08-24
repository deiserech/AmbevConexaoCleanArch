using AmbevConexao.Domain.Aluno;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Aluno;


public class AdicionarAlunoCommand : IRequest<AdicionarAlunoResponse>
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }

    public AdicionarAlunoCommand(string nome, string endereco, string email)
    {
        Nome = nome;
        Endereco = endereco;
        Email = email;
    }
}

public class AdicionarAlunoResponse
{
    public List<AlunoEntity> Alunos{ get; set; }
}

public sealed class AdicionarAluno : IRequestHandler<AdicionarAlunoCommand, AdicionarAlunoResponse>
{
    private readonly IAlunoRepository _repository;

    public AdicionarAluno(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdicionarAlunoResponse> Handle(AdicionarAlunoCommand request, CancellationToken cancellationToken)
    {
        var alunoEntidade = AlunoEntity.NovoAluno(request.Nome, request.Endereco, request.Email);

        _repository.Incluir(alunoEntidade);

        var result =  _repository.SelecionarTudo();

        return new AdicionarAlunoResponse
        {
            Alunos = result
        };
    }
}
