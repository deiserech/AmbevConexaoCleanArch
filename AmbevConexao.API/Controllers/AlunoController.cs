using AmbevConecxao.Application.UseCases.Aluno;
using AmbevConexao.Domain.Aluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmbevConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunoController(IAlunoRepository repository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoEntity>> Get()
        {
            var result = await _mediator.Send(new BuscarAlunosCommand());
            return result.Alunos;
        }

        [HttpGet("{id}")]
        public async Task< AlunoEntity> Get(int id)
        {
            var result = await _mediator.Send(new BuscarAlunoCommand(id));

            return result.Aluno;
        }

        [HttpPost]
        public async Task< IEnumerable<AlunoEntity>> Post([FromBody] AdicionarAlunoCommand alunoCommand)
        {
            var result = await _mediator.Send(alunoCommand);

            return result.Alunos;
        }

        [HttpPatch("{id}")]
        public async Task<AlunoEntity> Put(int id, [FromBody] AlterarAlunoCommand alunoCommand)
        {
            var result = await _mediator.Send(alunoCommand);

            return result.Aluno;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await _mediator.Send(new InativarAlunoCommand(id));
        }
    }
}
