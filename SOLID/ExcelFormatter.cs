using System;

// [cite_start]// Implements formatting for Excel output [cite: 23]
public class ExcelFormatter : IReportFormatter
{
    public void Format(string content)
    {
        Console.WriteLine($"Formatting report content for Excel: '{content}'");
    }
}