using System;

namespace Sms.Splitter
{
    public class Splitter
    {
        private readonly GsmValidator _validator = new GsmValidator();
        public SplitResult Split(string content, CharacterSet overrideCharacterSet = CharacterSet.Unknown)
        {
            var charSet = GetCharset(content, overrideCharacterSet);
            ISplitMessage messageSplitter = CreateMessageSplitter(charSet);
            var result = messageSplitter.Split(content);
            return result;
        }

        private ISplitMessage CreateMessageSplitter(CharacterSet characterSet)
        {
            if (characterSet == CharacterSet.Gsm)
            {
                return new GsmSplitter(_validator);
            }
            else if (characterSet == CharacterSet.Unicode)
            {
                return new UnicodeSplitter();
            }
            throw new Exception("Unknown character set.");
        }

        private CharacterSet GetCharset(string content, CharacterSet overrideCharacterSet)
        {
            if (overrideCharacterSet != CharacterSet.Unknown)
            {
                return overrideCharacterSet;
            }
            if (_validator.Validate(content))
            {
                return CharacterSet.Gsm;
            }
            return CharacterSet.Unicode;
        }
    }
}