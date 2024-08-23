using AmbevConecxao.Application.UseCases.Professor;
using AmbevConexao.API.Filters;
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

        if (result.Professor == null) throw new NotFoundException("Professor não existe");

        return result.Professor;
    }

    [HttpPost]
    public async Task<IEnumerable<ProfessorEntity>> Post([FromBody] AdicionarProfessorCommand alunoCommand)
    {
        var result = await _mediator.Send(alunoCommand);

        return result.Professores;
    }

    [HttpPut("{id}")]
    public async Task<ProfessorEntity> Put(int id, [FromBody] AlterarProfessorCommand alunoCommand)
    {
        var result = await _mediator.Send(alunoCommand);

        return result.Professor;
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var result = await _mediator.Send(new ExcluirProfessorCommand(id));
    }
}

