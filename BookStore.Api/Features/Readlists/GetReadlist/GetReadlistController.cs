using BookStore.Api.Common;
using BookStore.Api.Features.Readlists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ReadlistStore.Api.Features.Readlists.GetReadlist;

[Tags(ControllerTags.Readlists)]
public class GetReadlistController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Readlist), StatusCodes.Status200OK)]
    [HttpGet("readlists/{id}", Name = nameof(GetReadlist))]
    public async Task<IActionResult> GetReadlist(
        [Required][FromRoute] Guid id)
    {
        var request = new GetReadlistRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
