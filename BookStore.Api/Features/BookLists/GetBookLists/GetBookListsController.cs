using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.BookLists.GetBookLists;

[Tags(ControllerTags.BookLists)]
public class GetBookListsController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookList), StatusCodes.Status200OK)]
    [HttpGet("book-lists", Name = nameof(GetBookLists))]
    public async Task<IActionResult> GetBookLists()
    {
        var request = new GetBookListsRequest();
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
