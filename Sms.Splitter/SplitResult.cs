using System.Collections.Generic;

namespace Sms.Splitter
{
    public class SplitResult
    {

        public CharacterSet CharacterSet { get; set; }
        public int TotalBytes { get; set; }
        public int TotalLength { get; set; }
        public int RemainingInPart { get; set; }
		public int TotalCharacters { get; set; }

		public List<SplitPart> Parts = new List<SplitPart>();
    }
    public class SplitPart
    {
        public string Content { get; set; }
        public int Length { get; set; }
        public int Bytes { get; set; }
		public int Characters { get; set; }
	}
}