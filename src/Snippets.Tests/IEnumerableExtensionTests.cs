using NUnit.Framework;
using System.Collections.Generic;

namespace Snippets.Tests;
[TestFixture]
public class IEnumerableExtensionsTests
{
    [Test]
    public void None_WhenCollectionIsNull_ItShouldReturnTrue()
    {
        List<int>? collection = null;
        var result = collection!.None();

        Assert.True(result);
    }

    [Test]
    public void None_WhenCollectionIsEmpty_ItShouldReturnTrue()
    {
        List<int> collection = new();
        var result = collection.None();

        Assert.True(result);
    }

    [Test]
    public void None_WhenCollectionHasOneOrMoreElements_ItShouldReturnFalse()
    {
        List<int> collection = new() { 9 };
        var result = collection.None();

        Assert.False(result);
    }
}
