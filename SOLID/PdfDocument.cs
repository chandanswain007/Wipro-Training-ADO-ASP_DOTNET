using System;

// [cite_start]// A concrete product [cite: 73]
public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF document.");
    public void Close() => Console.WriteLine("Closing PDF document.");
}