using BookStore.Api.Common;
using BookStore.Api.Features.Books.DeleteBook;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.DeleteBook;

[Tags("Books")]
public class DeleteBookController : ApiControllerBase
{
    public DeleteBookController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpDelete("books/{id}", Name = nameof(DeleteBook))]
    public async Task<IActionResult> DeleteBook(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteBookRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
