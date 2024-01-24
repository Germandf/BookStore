using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

public record UpdateBookPriceRequest(
    Guid Id,
    decimal Price)
    : UpdateBookPriceRequestDto(Price), IRequest<Result<Success>>;
