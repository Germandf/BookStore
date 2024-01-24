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
    [HttpPut("books/{id}/price", Name = nameof(UpdateBookPrice))]
    public async Task<IActionResult> UpdateBookPrice(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookPriceRequestDto dto)
    {
        var request = (UpdateBookPriceRequest) dto with { Id = id };
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
