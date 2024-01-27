using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookLists.CreateBookList;

[Tags(ControllerTags.BookLists)]
public class CreateBookListController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookList), StatusCodes.Status200OK)]
    [HttpPost("book-lists", Name = nameof(CreateBookList))]
    public async Task<IActionResult> CreateBookList(
        [Required][FromBody] CreateBookListRequest request)
    {
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
