namespace Snippets;
public static class IEnumerableExtensions
{
    public static bool None<TSource>(this IEnumerable<TSource>? source)
    {
        if (source is null)
        {
            return true;
        }

        return !source.Any();
    }
}
