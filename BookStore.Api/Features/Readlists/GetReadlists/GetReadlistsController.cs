using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.Readlists.GetReadlists;

[Tags(ControllerTags.Readlists)]
public class GetReadlistsController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Readlist), StatusCodes.Status200OK)]
    [HttpGet("readlists", Name = nameof(GetReadlists))]
    public async Task<IActionResult> GetReadlists()
    {
        var request = new GetReadlistsRequest();
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
