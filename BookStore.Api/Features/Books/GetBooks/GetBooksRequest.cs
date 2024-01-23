using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.GetBooks;

public record GetBooksRequest : IRequest<Result<List<Book>>>;
