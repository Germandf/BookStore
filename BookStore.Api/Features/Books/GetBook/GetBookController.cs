using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.GetBook;

[Tags("Books")]
public class GetBookController : ApiControllerBase
{
    public GetBookController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [HttpGet("books/{id}", Name = nameof(GetBook))]
    public async Task<IActionResult> GetBook(
        [Required][FromRoute] Guid id)
    {
        var request = new GetBookRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
