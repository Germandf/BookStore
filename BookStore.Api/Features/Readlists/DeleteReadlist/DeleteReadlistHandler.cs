using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.DeleteReadlist;

public class DeleteReadlistHandler(
    IRepository<Readlist> ReadlistRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteReadlistRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(DeleteReadlistRequest request, CancellationToken cancellationToken)
    {
        var Readlist = await ReadlistRepository.GetById(request.Id);

        if (Readlist is null)
            return Result.Fail(Errors.EntityNotFound<Readlist>(request.Id));

        ReadlistRepository.Remove(Readlist);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
