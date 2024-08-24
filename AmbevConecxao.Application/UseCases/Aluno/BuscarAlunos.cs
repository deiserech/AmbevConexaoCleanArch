using AmbevConexao.Domain.Aluno;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Aluno;
public class BuscarAlunoCommand : IRequest<BuscarAlunoResponse>
{
    public int Id { get; set; }

    public BuscarAlunoCommand(int id)
    {
        Id = id;
    }
}

public class BuscarAlunosCommand : IRequest<BuscarAlunosResponse>
{
}

public class BuscarAlunosResponse
{
    public List<AlunoEntity> Alunos { get; set; }
}

public class BuscarAlunoResponse
{
    public AlunoEntity Aluno { get; set; }
}

public sealed class BuscarAluno : IRequestHandler<BuscarAlunoCommand, BuscarAlunoResponse>
{
    private readonly IAlunoRepository _repository;

    public BuscarAluno(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarAlunoResponse> Handle(BuscarAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = _repository.Selecionar(request.Id);

        return new BuscarAlunoResponse
        {
            Aluno = aluno
        };
    }
}

public sealed class BuscarAlunos : IRequestHandler<BuscarAlunosCommand, BuscarAlunosResponse>
{
    private readonly IAlunoRepository _repository;

    public BuscarAlunos(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarAlunosResponse> Handle(BuscarAlunosCommand request, CancellationToken cancellationToken)
    {
        var alunos = _repository.SelecionarTudo();

        return new BuscarAlunosResponse
        {
            Alunos = alunos.ToList()
        };

    }
}
