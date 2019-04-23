using System.Collections.Generic;

namespace Sms.Splitter
{
    public class SplitResult
    {
        /// <summary>
        /// Character set used by message (Unicode or GSM)
        /// </summary>
        public CharacterSet CharacterSet { get; set; }
        /// <summary>
        /// The total amount of bytes for the message
        /// </summary>
        public int TotalBytes { get; set; }
        /// <summary>
        /// How many bytes remain in the last part
        /// </summary>
        public int BytesRemainingInLastPart { get; set; }
        /// <summary>
        /// The total amount of characters for the message. Is the same as amount of bytes for GSM but is half the amount of bytes for Unicode.
        /// </summary>
		public int TotalCharacters { get; set; }
        /// <summary>
        /// A list of all the parts in the message
        /// </summary>
		public List<SplitPart> Parts = new List<SplitPart>();
    }
    public class SplitPart
    {
        /// <summary>
        /// Content of the part
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// The number of bytes used for this specific part
        /// </summary>
        public int Bytes { get; set; }
        /// <summary>
        /// The amount of characters for this specific part. Is the same as amount of bytes for GSM but is half the amount of bytes for Unicode.
        /// </summary>
		public int Characters { get; set; }
	}
}