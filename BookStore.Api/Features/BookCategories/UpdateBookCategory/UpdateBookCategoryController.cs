using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

[Tags("BookCategories")]
public class UpdateBookCategoryController : ApiControllerBase
{
    public UpdateBookCategoryController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpPut("book-categories/{id}", Name = nameof(UpdateBookCategory))]
    public async Task<IActionResult> UpdateBookCategory(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookCategoryRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
