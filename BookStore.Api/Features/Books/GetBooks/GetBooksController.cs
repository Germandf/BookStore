using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.Books.GetBooks;

[Tags(ControllerTags.Books)]
public class GetBooksController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [HttpGet("books", Name = nameof(GetBooks))]
    public async Task<IActionResult> GetBooks()
    {
        var request = new GetBooksRequest();
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
