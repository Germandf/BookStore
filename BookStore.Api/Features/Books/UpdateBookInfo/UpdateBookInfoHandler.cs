﻿using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

public class UpdateBookInfoHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBookInfoRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(UpdateBookInfoRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id, cancellationToken);

        if (book is null)
            return Result.Fail("Book not found");

        if (book.ISBN is not null)
            return Result.Fail("Book info cannot be updated if the book has an ISBN");

        book.Title = request.Title;
        book.Author = request.Author;

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}