using BookStore.Api.Features.Readlists;
using FluentResults;
using MediatR;

namespace ReadlistStore.Api.Features.Readlists.GetReadlist;

public record GetReadlistRequest(Guid Id) : IRequest<Result<Readlist>>;
