using MediatR;
using FluentResults;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public record UpdateBookCategoryRequest(
    Guid Id, 
    string Name, 
    string Description) 
    : UpdateBookCategoryRequestDto(Name, Description), IRequest<Result<BookCategory>>;
