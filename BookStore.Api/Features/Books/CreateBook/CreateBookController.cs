using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.CreateBook;

[Tags("Books")]
public class CreateBookController : ApiControllerBase
{
    public CreateBookController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [HttpPost("books", Name = nameof(CreateBook))]
    public async Task<IActionResult> CreateBook(
        [Required][FromBody] CreateBookRequest request)
    {
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
