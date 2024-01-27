using BookStore.Api.Features.Readlists;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace ReadlistStore.Api.Features.Readlists.GetReadlist;

public class GetReadlistHandler(
    IRepository<Readlist> bookRepository)
    : IRequestHandler<GetReadlistRequest, Result<Readlist>>
{
    public async Task<Result<Readlist>> Handle(GetReadlistRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail($"Readlist with id {request.Id} was not found");

        return Result.Ok(book);
    }
}
