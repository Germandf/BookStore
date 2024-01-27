using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Features.BookCategories.GetBookCategories;

[Tags(ControllerTags.BookCategories)]
public class GetBookCategoriesController(ISender sender) : ApiControllerBase(sender)
{
    [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
    [HttpGet("book-categories", Name = nameof(GetBookCategories))]
    public async Task<IActionResult> GetBookCategories()
    {
        var request = new GetBookCategoriesRequest();
        var result = await Mediator.Send(request);
        return ToHttpResponse(result);
    }
}
