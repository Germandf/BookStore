using BookStore.Api.Features.Books.UpdateBookInfo;
using MediatR;
using FluentResults;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

public record UpdateBookInfoRequest(
    Guid Id,
    string Title,
    string Author)
    : IRequest<Result<Success>>;
