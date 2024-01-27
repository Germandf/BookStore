using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.DeleteReadlist;

public record DeleteReadlistRequest(
    Guid Id)
    : IRequest<Result<Success>>;
