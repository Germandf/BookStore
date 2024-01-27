using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

[Tags(ControllerTags.BookCategories)]
public class UpdateBookCategoryController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpPut("book-categories/{id}", Name = nameof(UpdateBookCategory))]
    public async Task<IActionResult> UpdateBookCategory(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookCategoryRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
