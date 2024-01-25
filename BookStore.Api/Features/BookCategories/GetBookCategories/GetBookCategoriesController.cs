using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.BookCategories.GetBookCategories;

[Tags("BookCategories")]
public class GetBookCategoriesController : ApiControllerBase
{
    public GetBookCategoriesController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpGet("book-categories", Name = nameof(GetBookCategories))]
    public async Task<IActionResult> GetBookCategories()
    {
        var request = new GetBookCategoriesRequest();
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
