using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.DeleteBook;

[Tags(ControllerTags.Books)]
public class DeleteBookController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpDelete("books/{id}", Name = nameof(DeleteBook))]
    public async Task<IActionResult> DeleteBook(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteBookRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
