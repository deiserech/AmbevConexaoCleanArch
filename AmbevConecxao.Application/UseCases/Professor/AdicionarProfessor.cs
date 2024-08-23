using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Professor;
using MediatR;

namespace AmbevConecxao.Application.UseCases.Professor;


public class AdicionarProfessorCommand : IRequest<AdicionarProfessorResponse>
{
    public string Nome { get; set; }
    public string Email{ get; set; }
    public TurnoEnum Turno { get; set; }

    public AdicionarProfessorCommand(string nome, string email, TurnoEnum turno)
    {
        Nome = nome;
        Email = email;
        Turno = turno;
    }
}

public class AdicionarProfessorResponse
{
    public List<ProfessorEntity> Professores { get; set; }
}

public sealed class AdicionarProfessor : IRequestHandler<AdicionarProfessorCommand, AdicionarProfessorResponse>
{
    private readonly IProfessorRepository _repository;

    public AdicionarProfessor(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdicionarProfessorResponse> Handle(AdicionarProfessorCommand request, CancellationToken cancellationToken)
    {
        var alunoEntidade = ProfessorEntity.NovoProfessor(request.Nome, request.Email, request.Turno);

        _repository.Incluir(alunoEntidade);

        var result = _repository.SelecionarTudo();

        return new AdicionarProfessorResponse
        {
            Professores = result
        };
    }
}
