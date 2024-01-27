using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

[Tags(ControllerTags.BookCategories)]
public class DeleteBookCategoryController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpDelete("book-categories/{id}", Name = nameof(DeleteBookCategory))]
    public async Task<IActionResult> DeleteBookCategory(
        [Required][FromRoute] Guid id)
    {
        var request = new DeleteBookCategoryRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
