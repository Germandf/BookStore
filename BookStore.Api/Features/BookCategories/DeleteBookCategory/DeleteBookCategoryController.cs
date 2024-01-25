using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

[Tags("BookCategories")]
public class DeleteBookCategoryController : ApiControllerBase
{
    public DeleteBookCategoryController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpDelete("book-categories/{id}", Name = nameof(DeleteBookCategory))]
    public async Task<IActionResult> DeleteBookCategory(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteBookCategoryRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
