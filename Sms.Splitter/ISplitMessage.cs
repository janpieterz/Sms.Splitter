namespace Sms.Splitter
{
    internal interface ISplitMessage
    {
        SplitResult Split(string content);
    }
}