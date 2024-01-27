namespace BookStore.Api.Features.Readlists;

public class Readlist
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid UserId { get; set; }
    public List<ReadlistItem> Items { get; } = [];
}
