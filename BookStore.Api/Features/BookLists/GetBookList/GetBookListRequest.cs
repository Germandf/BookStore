using BookStore.Api.Features.BookLists;
using FluentResults;
using MediatR;

namespace BookListStore.Api.Features.BookLists.GetBookList;

public record GetBookListRequest(Guid Id) : IRequest<Result<BookList>>;
