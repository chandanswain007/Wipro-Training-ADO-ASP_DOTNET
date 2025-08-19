using System;

// [cite_start]// Implements formatting for PDF output [cite: 23]
public class PdfFormatter : IReportFormatter
{
    public void Format(string content)
    {
        Console.WriteLine($"Formatting report content for PDF: '{content}'");
    }
}