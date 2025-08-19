using System;

// [cite_start]// A concrete product [cite: 73]
public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word document.");
    public void Close() => Console.WriteLine("Closing Word document.");
}