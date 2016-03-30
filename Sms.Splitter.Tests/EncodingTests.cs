using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace Sms.Splitter.Tests
{
    public class EncodingTests
    {
        [Theory]
        [InlineData("Hi, this is a test GSM message", CharacterSet.Gsm)]
        [InlineData("Hi, this is a test GSM message \r\n With an enter in it", CharacterSet.Gsm)]
        [InlineData("Hi, this is a test Unicode messagë", CharacterSet.Unicode)]
        public void TestEncodingRecognition(string content, CharacterSet expectedCharacterSet)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content);
            Assert.Equal(expectedCharacterSet, result.CharacterSet);
        }

        [Theory]
        [InlineData("Hi, this is a test GSM message", CharacterSet.Unicode)]
        [InlineData("Hi, this is a test Unicode messagë", CharacterSet.Gsm)]
        public void TestEncodingOverride(string content, CharacterSet overrideCharacterSet)
        {
            Splitter splitter = new Splitter();
            var result = splitter.Split(content, overrideCharacterSet);
            Assert.Equal(overrideCharacterSet, result.CharacterSet);
        }
    }
}
