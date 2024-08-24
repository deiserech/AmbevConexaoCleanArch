using AmbevConecxao.Application.UseCases.Curso;
using AmbevConexao.Domain.Curso;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmbevConexao.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursoController(ICursoRepository repository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CursoEntity>> Get()
        {
            var result = await _mediator.Send(new BuscarCursosCommand());
            return result.Cursos;
        }

        [HttpGet("{id}")]
        public async Task<CursoEntity> Get(int id)
        {
            var result = await _mediator.Send(new BuscarCursoCommand(id));

            return result.Curso;
        }

        [HttpPost]
        public async Task<IEnumerable<CursoEntity>> Post([FromBody] AdicionarCursoCommand cursoCommand)
        {
            var result = await _mediator.Send(cursoCommand);

            return result.Cursos;
        }

        [HttpPatch("/iniciar/{id}")]
        public async Task<CursoEntity> Patch(int id, [FromBody] IniciarCursoCommand cursoCommand)
        {
            cursoCommand.Id = id;
            var result = await _mediator.Send(cursoCommand);

            return result.Curso;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await _mediator.Send(new InativarCursoCommand(id));
        }
    }
}
