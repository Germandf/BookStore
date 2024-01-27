using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Readlists.DeleteReadlist;

[Tags(ControllerTags.Readlists)]
public class DeleteReadlistController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Readlist), StatusCodes.Status200OK)]
    [HttpDelete("readlists/{id}", Name = nameof(DeleteReadlist))]
    public async Task<IActionResult> DeleteReadlist(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteReadlistRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
