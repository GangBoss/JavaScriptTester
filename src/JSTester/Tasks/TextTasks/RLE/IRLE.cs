namespace JSTester.Tasks.TextTasks.RLE
{
    interface IRLE
    {
        public char EscapeSymbol { get; }

        string EscapeEncode(string line);
        string JumpEncode(string line);
        string EscapeDecode(string line);
        string JumpDecode(string line);
    }
}
