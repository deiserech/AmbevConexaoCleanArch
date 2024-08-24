using AmbevConexao.Domain.Professor;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Professor;

public class BuscarProfessorCommand : IRequest<BuscarProfessorResponse>
{
    public int Id { get; set; }

    public BuscarProfessorCommand(int id)
    {
        Id = id;
    }
}

public class BuscarProfessoresCommand : IRequest<BuscarProfessoresResponse>
{
}

public class BuscarProfessoresResponse
{
    public List<ProfessorEntity> Professores { get; set; }
}

public class BuscarProfessorResponse
{
    public ProfessorEntity Professor { get; set; }
}

public sealed class BuscarProfessor : IRequestHandler<BuscarProfessorCommand, BuscarProfessorResponse>
{
    private readonly IProfessorRepository _repository;

    public BuscarProfessor(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarProfessorResponse> Handle(BuscarProfessorCommand request, CancellationToken cancellationToken)
    {
        var aluno = _repository.Selecionar(request.Id);

        return new BuscarProfessorResponse
        {
            Professor = aluno
        };
    }
}

public sealed class BuscarProfessores : IRequestHandler<BuscarProfessoresCommand, BuscarProfessoresResponse>
{
    private readonly IProfessorRepository _repository;

    public BuscarProfessores(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<BuscarProfessoresResponse> Handle(BuscarProfessoresCommand request, CancellationToken cancellationToken)
    {
        var alunos = _repository.SelecionarTudo();

        return new BuscarProfessoresResponse
        {
            Professores = alunos.ToList()
        };

    }
}
