using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Readlists.CreateReadlist;

public class CreateReadlistHandler(
    IRepository<Readlist> ReadlistRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateReadlistRequest, Result<Readlist>>
{
    public async Task<Result<Readlist>> Handle(CreateReadlistRequest request, CancellationToken cancellationToken)
    {
        var Readlist = new Readlist
        {
            Name = request.Name,
            Description = request.Description,
            UserId = request.UserId
        };

        ReadlistRepository.Add(Readlist);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Readlist;
    }
}
