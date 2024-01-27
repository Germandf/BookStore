using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.GetBook;

[Tags(ControllerTags.Books)]
public class GetBookController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [HttpGet("books/{id}", Name = nameof(GetBook))]
    public async Task<IActionResult> GetBook(
        [Required][FromRoute] Guid id)
    {
        var request = new GetBookRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
