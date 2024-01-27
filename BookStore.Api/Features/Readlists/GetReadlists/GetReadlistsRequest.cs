using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.GetReadlists;

public record GetReadlistsRequest : IRequest<Result<List<Readlist>>>;
