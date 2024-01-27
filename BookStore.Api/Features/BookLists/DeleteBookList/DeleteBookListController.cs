using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookLists.DeleteBookList;

[Tags(ControllerTags.BookLists)]
public class DeleteBookListController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookList), StatusCodes.Status200OK)]
    [HttpDelete("book-lists/{id}", Name = nameof(DeleteBookList))]
    public async Task<IActionResult> DeleteBookList(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteBookListRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
