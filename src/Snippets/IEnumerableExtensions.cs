namespace Snippets;
public static class IEnumerableExtensions
{
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any();
        }
}
