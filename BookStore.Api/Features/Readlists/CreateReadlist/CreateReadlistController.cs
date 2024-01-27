using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Readlists.CreateReadlist;

[Tags(ControllerTags.Readlists)]
public class CreateReadlistController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Readlist), StatusCodes.Status200OK)]
    [HttpPost("readlists", Name = nameof(CreateReadlist))]
    public async Task<IActionResult> CreateReadlist(
        [Required][FromBody] CreateReadlistRequest request)
    {
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
