namespace Common.Extensions;

public static class IEnumerableExtensions
{
    public static bool In<TElement>(this TElement source, params TElement[] list)
    {
        return list?.Contains(source) ?? false;
    }

    public static bool None<TSource>(this IEnumerable<TSource>? source)
    {
        if (source is null)
        {
            return true;
        }

        return !source.Any();
    }
}
