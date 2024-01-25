using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

[Tags("Books")]
public class UpdateBookPriceController : ApiControllerBase
{
    public UpdateBookPriceController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPatch("books/{id}/price", Name = nameof(UpdateBookPrice))]
    public async Task<IActionResult> UpdateBookPrice(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookPriceRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
