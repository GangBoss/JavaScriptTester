namespace JSTester.Tasks.TextTasks.Haffman
{
    interface IHaffman
    {
        (string text,string dictionary)Encode(string line);
        string Decode(string line, string dictionary);
    }
}