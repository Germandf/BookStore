namespace BookStore.Api.Common.Settings;

public class RabbitMqSettings
{
    public required string Uri { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
