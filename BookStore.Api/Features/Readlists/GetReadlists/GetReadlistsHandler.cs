using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.GetReadlists;

public class GetReadlistsHandler(IRepository<Readlist> ReadlistRepository) : IRequestHandler<GetReadlistsRequest, Result<List<Readlist>>>
{
    public async Task<Result<List<Readlist>>> Handle(GetReadlistsRequest request, CancellationToken cancellationToken)
    {
        var Readlists = await ReadlistRepository.GetAll();

        return Readlists;
    }
}
