using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

[Tags(ControllerTags.BookCategories)]
public class CreateBookCategoryController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpPost("book-categories", Name = nameof(CreateBookCategory))]
    public async Task<IActionResult> CreateBookCategory(
        [Required][FromBody] CreateBookCategoryRequest request)
    {
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
