using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.DeleteBookList;

public record DeleteBookListRequest(
    Guid Id)
    : IRequest<Result<Success>>;
