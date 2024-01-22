using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.CreateBook;

public class CreateBookController : ApiControllerBase
{
    public CreateBookController(ISender mediator) : base(mediator)
    {
    }

    [ProducesResponseType(typeof(CreateBookResponse), StatusCodes.Status200OK)]
    [HttpPost("books", Name = nameof(CreateBook))]
    public async Task<IActionResult> CreateBook(
        [Required][FromBody] CreateBookRequest request)
    {
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}
