using System;
using System.Linq;

namespace Sms.Splitter
{
    internal class GsmSplitter : ISplitMessage
    {
        private readonly GsmValidator _validator;

        public GsmSplitter(GsmValidator validator)
        {
            _validator = validator;
        }

        public SplitResult Split(string content)
        {
            var result = new SplitResult
            {
                CharacterSet = CharacterSet.Gsm
            };

            if (string.IsNullOrEmpty(content))
            {
                result.Parts.Add(new SplitPart()
                {
                    Content = string.Empty
                });
                return result;
            }

            var walker = GetEmptyWalker();

            for (int i = 0; i < content.Length; i++)
            {
                char character = content[i];
                if (!_validator.ValidateCharacter(character))
                {
                    if (Char.IsHighSurrogate(character))
                    {
                        i++;
                    }
                    character = '\u0020';
                }
                else if (_validator.ValidateExtendedCharacter(character))
                {
                    if (walker.Bytes == 152)
                    {
                        AddPart(result, ref walker);
                    }
                    walker.Bytes++;
                }

                walker.Bytes++;
                walker.Length++;
                walker.Content += character;
                if (walker.Bytes == 153)
                {
                    AddPart(result, ref walker);
                }
            }

            if (walker.Bytes > 0)
            {
                AddPart(result, ref walker);
            }

            if (result.Parts.Count == 2 && result.TotalBytes <= 160)
            {
                SplitPart part = new SplitPart
                {
                    Bytes = result.TotalBytes,
                    Content = result.Parts[0].Content + result.Parts[1].Content,
					Characters = result.TotalBytes
                };
                result.Parts.Clear();
                result.Parts.Add(part);
            }
            CalculateRemainingInPart(result);
            return result;
        }

        private void CalculateRemainingInPart(SplitResult result)
        {
            var max = result.Parts.Count == 1 ? 160 : 153;
            result.BytesRemainingInLastPart = (max - result.Parts.Last().Bytes) / 1;
        }

        private class MessageWalker
        {
            public int Bytes { get; set; }
            public int Length { get; set; }
            public string Content { get; set; }
        }

        private void AddPart(SplitResult result, ref MessageWalker walker)
        {
            result.Parts.Add(new SplitPart
            {
                Bytes = walker.Bytes,
                Content = walker.Content,
                Characters = walker.Bytes
            });
            result.TotalBytes += walker.Bytes;
			result.TotalCharacters = result.TotalBytes;
			walker = GetEmptyWalker();
        }

        private MessageWalker GetEmptyWalker()
        {
            return new MessageWalker()
            {
                Length = 0,
                Bytes = 0,
                Content = string.Empty
            };
        }
    }
}