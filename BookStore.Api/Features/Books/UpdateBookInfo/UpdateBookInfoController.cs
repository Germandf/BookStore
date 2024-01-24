using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

[Tags("Books")]
public class UpdateBookInfoController : ApiControllerBase
{
    public UpdateBookInfoController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPut("books/{id}/info", Name = nameof(UpdateBookInfo))]
    public async Task<IActionResult> UpdateBookInfo(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookInfoRequestDto dto)
    {
        var request = (UpdateBookInfoRequest) dto with { Id = Guid.NewGuid() };
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
