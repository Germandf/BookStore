using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.CreateBook;

[Tags(ControllerTags.Books)]
public class CreateBookController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [HttpPost("books", Name = nameof(CreateBook))]
    public async Task<IActionResult> CreateBook(
        [Required][FromBody] CreateBookRequest request)
    {
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
