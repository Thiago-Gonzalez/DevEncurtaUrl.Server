using DevEncurtaUrl.Application.Commands.AddShortenedLinkCommand;
using DevEncurtaUrl.Application.Commands.DeleteShortenedLinkCommand;
using DevEncurtaUrl.Application.Commands.UpdateShortenedLinkCommand;
using DevEncurtaUrl.Application.Queries.GetAllShortenedLinksQuery;
using DevEncurtaUrl.Application.Queries.GetShortenedLinkByCodeQuery;
using DevEncurtaUrl.Application.Queries.GetShortenedLinkByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        // api/shortenedLinks
        [HttpPost]
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