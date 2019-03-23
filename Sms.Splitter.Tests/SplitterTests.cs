using System.Collections.Generic;
using Xunit;

namespace Sms.Splitter.Tests
{
    public class SplitterTests
    {
        [Theory]
        [MemberData(nameof(MessageSplittingTestsData.GsmTestData), MemberType = typeof(MessageSplittingTestsData))]
        public void TestFullGsmSplitter(string content, int expectedTotalBytes, int expectedTotalLength,  List<SplitPart> expectedParts)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content, CharacterSet.Gsm);
            Assert.Equal(expectedTotalBytes, result.TotalBytes);
            Assert.Equal(expectedTotalLength, result.TotalLength);
            Assert.Equal(expectedParts.Count, result.Parts.Count);
            Assert.Equal(expectedParts, result.Parts, new SplitPartComparer());
        }

        [Theory]
        [MemberData(nameof(MessageSplittingTestsData.UnicodeTestData), MemberType = typeof(MessageSplittingTestsData))]
        public void TestFullUnicodeSplitter(string content, int expectedTotalBytes, int expectedTotalLength, List<SplitPart> expectedParts)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content, CharacterSet.Unicode);
            Assert.Equal(expectedTotalBytes, result.TotalBytes);
            Assert.Equal(expectedTotalLength, result.TotalLength);
            Assert.Equal(expectedParts.Count, result.Parts.Count);
            Assert.Equal(expectedParts, result.Parts, new SplitPartComparer());
        }

        [Theory]
        [InlineData("Snowman shows off!", 142)]
        [InlineData("Snowman shows off! ☃", 50)]
        [InlineData("Snowman shows off! ☃ Snowman shows off! ☃ Snowman shows off! ☃ Snowman shows off! ☃ ", 50)]
        [InlineData("මට නැහැaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccc sdddddddddddddddddddddddddddddddddddddddddddddddddddd", 37)]
        [InlineData("XXXXXXXXXXXXXXXXXXXX 50% ooo YYYYYYY when yoy sxxxx £$30 😍 o mouse! Click http://zzzzzzzzz.zzzz of xse AAAAA50% @ bbbbbbb.co.uk TKCx Opppux STO Top 077777777777", 40)]
        public void TestRemainingParts(string content, int expectedRemaining)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content);
            Assert.Equal(expectedRemaining, result.RemainingInPart);
        }
    }
}
