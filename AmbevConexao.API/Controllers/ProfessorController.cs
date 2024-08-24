using AmbevConecxao.Application.UseCases.Professor;
using AmbevConexao.Domain.Professor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmbevConexao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessorController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfessorController(IProfessorRepository repository, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<ProfessorEntity>> Get()
    {
        var result = await _mediator.Send(new BuscarProfessoresCommand());
        return result.Professores;
    }

    [HttpGet("{id}")]
    public async Task<ProfessorEntity> Get(int id)
    {
        var result = await _mediator.Send(new BuscarProfessorCommand(id));

        return result.Professor;
    }

    [HttpPost]
    public async Task<IEnumerable<ProfessorEntity>> Post([FromBody] AdicionarProfessorCommand professorCommand)
    {
        var result = await _mediator.Send(professorCommand);

        return result.Professores;
    }

    [HttpPatch("{id}")]
    public async Task<ProfessorEntity> Put(int id, [FromBody] AlterarProfessorCommand professorCommand)
    {
        professorCommand.Id = id;
        var result = await _mediator.Send(professorCommand);

        return result.Professor;
    }
}

