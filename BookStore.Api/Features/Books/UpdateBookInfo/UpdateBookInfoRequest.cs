using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

public record UpdateBookInfoRequest(
    Guid Id,
    string Title,
    string Author)
    : IRequest<Result<Success>>;
