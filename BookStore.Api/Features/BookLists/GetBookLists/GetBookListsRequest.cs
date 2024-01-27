using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.GetBookLists;

public record GetBookListsRequest : IRequest<Result<List<BookList>>>;
