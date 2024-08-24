using AmbevConecxao.Application.UseCases.Aluno;
using AmbevConexao.Domain.Curso;
using MediatR;
using System.Text.Json.Serialization;

namespace AmbevConecxao.Application.UseCases.Curso;

public class IniciarCursoCommand : IRequest<IniciarCursoResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public int IdProfessor { get; set; }
    public DateTime DataInicio { get; set; }

    public IniciarCursoCommand(int id, int idProfessor, DateTime dataInicio)
    {
        Id = id;
        IdProfessor = idProfessor;
        DataInicio = dataInicio;
    }
}

public class IniciarCursoResponse
{
    public CursoEntity? Curso { get; set; }
}

public sealed class IniciarCurso : IRequestHandler<IniciarCursoCommand, IniciarCursoResponse>
{
    private readonly ICursoRepository _repository;

    public IniciarCurso(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IniciarCursoResponse> Handle(IniciarCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = _repository.Selecionar(request.Id);
        if (curso is null)
        {
            return new IniciarCursoResponse();
        }

        curso.AtivarCurso(request.DataInicio, request.IdProfessor);

        _repository.Alterar(curso);

        return new IniciarCursoResponse
        {
            Curso = curso
        };
    }
}
