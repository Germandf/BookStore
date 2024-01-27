using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.CreateReadlist;

public record CreateReadlistRequest(
    string Name,
    string Description,
    Guid UserId)
    : IRequest<Result<Readlist>>;
