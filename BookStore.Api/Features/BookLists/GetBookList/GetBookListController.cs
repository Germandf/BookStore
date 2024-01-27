using BookStore.Api.Common;
using BookStore.Api.Features.BookLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookListStore.Api.Features.BookLists.GetBookList;

[Tags(ControllerTags.BookLists)]
public class GetBookListController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookList), StatusCodes.Status200OK)]
    [HttpGet("book-lists/{id}", Name = nameof(GetBookList))]
    public async Task<IActionResult> GetBookList(
        [Required][FromRoute] Guid id)
    {
        var request = new GetBookListRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
