using System;
using System.Linq;

namespace Sms.Splitter
{
    internal class UnicodeSplitter : ISplitMessage
    {
        public SplitResult Split(string content)
        {
            var result = new SplitResult
            {
                CharacterSet = CharacterSet.Unicode
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
                if (Char.IsHighSurrogate(character))
                {
                    if (walker.Bytes == 132)
                    {
                        AddPart(result, ref walker, content, i - 1);
                    }
                    walker.Bytes += 2;
                    i++;
                }
                walker.Bytes += 2;
                walker.Length++;
                if (walker.Bytes == 134)
                {
                    AddPart(result, ref walker, content, i);
                }
            }

            if (walker.Bytes > 0)
            {
                AddPart(result, ref walker, content);
            }
            if (result.Parts.Count == 2 && result.TotalBytes <= 140)
            {
                SplitPart part = new SplitPart
                {
                    Content = result.Parts[0].Content + result.Parts[1].Content,
                    Length = result.TotalLength,
                    Bytes = result.TotalBytes
                };
                result.Parts.Clear();
                result.Parts.Add(part);
            }
            CalculateRemainingInPart(result);
            return result;
        }

        private void CalculateRemainingInPart(SplitResult result)
        {
            var max = result.Parts.Count == 1 ? 140 : 134;
            result.RemainingInPart = (max - result.Parts.Last().Bytes) / 2;
        }

        private void AddPart(SplitResult result, ref MessageWalker walker, string content, int? partEnd = null)
        {
            result.Parts.Add(new SplitPart()
            {
                Bytes = walker.Bytes,
                Length = walker.Length,
                Content = partEnd.HasValue ? content.Substring(walker.PartStart, partEnd.Value + 1) : content.Substring(walker.PartStart)
            });
            result.TotalBytes += walker.Bytes;
            result.TotalLength += walker.Length;
            walker.Bytes = 0;
            walker.Length = 0;
            walker.PartStart = partEnd + 1 ?? 0;
        }



        private MessageWalker GetEmptyWalker()
        {
            return new MessageWalker()
            {
                Length = 0,
                Bytes = 0,
                PartStart = 0
            };
        }

        private class MessageWalker
        {
            public int Bytes { get; set; }
            public int Length { get; set; }
            public int PartStart { get; set; }
        }
    }
}