namespace JSTester.Tasks.TextTasks.Caesar
{
    interface ICaesar
    {
        string Encode(string line, int offset);
        string Decode(string line, string dictionary);
    }
}