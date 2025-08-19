using System;
using System.IO;

// [cite_start]// Class responsible only for saving the report to a file [cite: 18]
public class FileSaver : IReportSaver
{
    public void Save(string content, string filePath)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Report saved to: {filePath}");
    }
}