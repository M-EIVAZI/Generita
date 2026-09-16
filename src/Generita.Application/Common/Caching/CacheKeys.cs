namespace Generita.Application.Common.Caching;

public static class CacheKeys
{
    public const string Home = "Home";
    public const string BookCategories = "BookCategories";

    public static string AuthorBooks(Guid authorId) => $"AuthorBook-{authorId}";

    public static string BookById(Guid bookId) => $"BookById-{bookId}";

    public static string BookContent(Guid bookId) => $"GetBookContent-{bookId}";

    public static string Payment(Guid paymentId) => $"Payment-{paymentId}";
}
