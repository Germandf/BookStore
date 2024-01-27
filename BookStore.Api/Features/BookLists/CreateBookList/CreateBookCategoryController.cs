using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookLists.CreateBookList;

[Tags("BookLists")]
public class CreateBookListController : ApiControllerBase
{
    public CreateBookListController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(BookList), StatusCodes.Status200OK)]
    [HttpPost("book-lists", Name = nameof(CreateBookList))]
    public async Task<IActionResult> CreateBookList(
        [Required][FromBody] CreateBookListRequest request)
    {
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
