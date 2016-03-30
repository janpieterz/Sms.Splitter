using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Extensions;

namespace Sms.Splitter.Tests
{
    public class PartsCountTest
    {

        [Theory]
        [InlineData("Hi, this is a test GSM message", 1)]
        [InlineData("Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long", 2)]
        [InlineData("Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long Hi, this is a test GSM message that is really long", 3)]
        [InlineData("Hi, this is a test Unicode messagë", 1)]
        public void TestPartsCount(string content, int expectedParts)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content);
            Assert.Equal(expectedParts, result.Parts.Count);
        }
    }

    public class SplitPartComparer : IEqualityComparer<SplitPart>
    {
        public bool Equals(SplitPart x, SplitPart y)
        {
            if (x.Bytes == y.Bytes && x.Length == y.Length && x.Content == y.Content)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(SplitPart obj)
        {
            return obj.Content.GetHashCode();
        }
    }
}
