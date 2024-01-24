using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

[Tags("BookCategories")]
public class CreateBookCategoryController : ApiControllerBase
{
    public CreateBookCategoryController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpPost("book-categories", Name = nameof(CreateBookCategory))]
    public async Task<IActionResult> CreateBookCategory(
        [Required][FromBody] CreateBookCategoryRequest request)
    {
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
