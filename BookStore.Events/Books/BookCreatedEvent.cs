﻿namespace BookStore.Events.Books;

public record BookCreatedEvent(
    Guid Id,
    string Title,
    string Author,
    decimal Price);
