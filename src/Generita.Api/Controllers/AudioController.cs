using Generita.Application.Audios.Queries.GetEntityAudioTags;
using Generita.Application.Audios.Queries.GetParagraphAudioTags;
using Generita.Application.Common.Dtos;

using MediatR;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioController:ApiController
    {
        private IMediator _mediator;

        public AudioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Audio/tags")]
        public async Task<IActionResult> GetAudioTags([FromQuery] string age, [FromQuery] string sense)
        {
            AudioTagsRequest model = new()
            {
                Age=age,
                Sense=sense
            };
            var query = new GetAudioTagsQuery(model);
            var result = await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
        [HttpGet("Audio/entity")]
        public async Task<IActionResult> GetEntityTags([FromQuery] string type)
        {
            var query=new GetEntityAudioQuery(type);
            var result=await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}
