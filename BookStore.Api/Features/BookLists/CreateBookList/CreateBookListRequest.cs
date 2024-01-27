using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.CreateBookList;

public record CreateBookListRequest(
    string Name,
    string Description,
    Guid UserId)
    : IRequest<Result<BookList>>;
