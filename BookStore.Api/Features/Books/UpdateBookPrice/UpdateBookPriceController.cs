using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

[Tags(ControllerTags.Books)]
public class UpdateBookPriceController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPatch("books/{id}/price", Name = nameof(UpdateBookPrice))]
    public async Task<IActionResult> UpdateBookPrice(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookPriceRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
