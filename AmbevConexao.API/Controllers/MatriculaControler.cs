using AmbevConecxao.Application.UseCases.Matricula;
using AmbevConexao.Domain.Matricula;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmbevConexao.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatriculaController(IMatriculaRepository repository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<MatriculaEntity>> Get()
        {
            var result = await _mediator.Send(new BuscarMatriculasCommand());
            return result.Matriculas;
        }

        [HttpGet("{id}")]
        public async Task<MatriculaEntity> Get(int id)
        {
            var result = await _mediator.Send(new BuscarMatriculaCommand(id));

            return result.Matricula;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] MatricularAlunoCommand matriculaCommand)
        {
            var result = await _mediator.Send(matriculaCommand);

            return result.StatusMatricula;
        }
    }
}

