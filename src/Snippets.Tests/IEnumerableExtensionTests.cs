using NUnit.Framework;

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
}
