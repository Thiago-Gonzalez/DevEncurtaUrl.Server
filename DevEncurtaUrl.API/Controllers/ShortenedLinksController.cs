using DevEncurtaUrl.Application.Commands.AddShortenedLink;
using DevEncurtaUrl.Application.Commands.DeleteShortenedLink;
using DevEncurtaUrl.Application.Commands.UpdateShortenedLink;
using DevEncurtaUrl.Application.Queries.GetAllShortenedLinks;
using DevEncurtaUrl.Application.Queries.GetShortenedLinkByCode;
using DevEncurtaUrl.Application.Queries.GetShortenedLinkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DevEncurtaUrl.API.Controllers
{
    [ApiController]
    [Route("api/shortenedLinks")]
    public class ShortenedLinksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShortenedLinksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/shortenedLinks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Requisição de listagem de links encurtados realizada!");

            var query = new GetAllShortenedLinksQuery();

            var links = await _mediator.Send(query);

            return Ok(links);
        }

        // api/shortenedLinks/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetShortenedLinkByIdQuery(id);

            var link = await _mediator.Send(query);

            if (link == null) return NotFound();

            return Ok(link);
        }

        /// <summary>
        /// Cadastrar um link encurtado
        /// </summary>
        /// <remarks>
        /// { "title": "ultimo-artigo Blog", "destionationLink": "https://www.luisdev.com.br/2021/08/18/10-livros-que-todo-desenvolvedor-net-deve-ler/" }
        /// </remarks>
        /// <param name="command">Dados de link</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso!</response>
        // api/shortenedLinks
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(AddShortenedLinkCommand command) 
        {
            var link = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = link.Id }, link);
        }

        // api/shortenedLinks/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateShortenedLinkCommand command)
        {
            command.SetId(id);
            var link = await _mediator.Send(command);

            if (link == null) return NotFound();

            return NoContent();
        }

        // api/shortenedLinks/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteShortenedLinkCommand(id);

            var link = await _mediator.Send(command);

            if (link == null) return NotFound();

            return NoContent();
        }

        // localhost:3000/code
        [HttpGet("/{code}")]
        public async Task<IActionResult> RedirectLink(string code)
        {
            var query = new GetShortenedLinkByCodeQuery(code);

            var link = await _mediator.Send(query);

            if (link == null) return NotFound();

            return Redirect(link.DestinationLink);
        }
    }
}