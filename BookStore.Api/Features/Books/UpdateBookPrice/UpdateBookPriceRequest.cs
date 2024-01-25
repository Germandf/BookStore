using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

public record UpdateBookPriceRequest(
    Guid Id,
    decimal Price)
    : IRequest<Result<Success>>;
