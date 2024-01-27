using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

[Tags(ControllerTags.Books)]
public class UpdateBookInfoController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPatch("books/{id}/info", Name = nameof(UpdateBookInfo))]
    public async Task<IActionResult> UpdateBookInfo(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookInfoRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
