
namespace BookStore.Api.Features.Books.RequestBookISBN;

public interface IISBNService
{
    Task<string> GetISBN(string title, string author);
}

public class ISBNService : IISBNService
{
    public async Task<string> GetISBN(string title, string author)
    {
        // Fake delay
        await Task.Delay(1000);
        return GenerateFakeISBN13();
    }

    private static string GenerateFakeISBN13()
    {
        Random rand = new Random();
        string isbn = "978-" + rand.Next(1, 10) + "-" + rand.Next(100, 1000) + "-" + rand.Next(10000, 100000) + "-";
        isbn += CalculateCheckDigit(isbn);
        return isbn;
    }

    private static char CalculateCheckDigit(string isbn)
    {
        int sum = 0;
        int weight = 1;
        foreach (char c in isbn)
        {
            if (c == '-') continue;
            sum += (c - '0') * weight;
            weight = weight == 1 ? 3 : 1;
        }

        int check = 10 - (sum % 10);
        if (check == 10) check = 0;

        return (char)(check + '0');
    }
}
