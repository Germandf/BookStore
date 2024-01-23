using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.Books.GetBooks;

[Tags("Books")]
public class GetBooksController : ApiControllerBase
{
    public GetBooksController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [HttpGet("books", Name = nameof(GetBooks))]
    public async Task<IActionResult> GetBooks()
    {
        var request = new GetBooksRequest();
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
