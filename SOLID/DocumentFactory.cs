using System;

// [cite_start]// The factory class for creating documents [cite: 72]
public class DocumentFactory
{
    // The factory method
    public static IDocument CreateDocument(string type)
    {
        return type.ToLower() switch
        {
            "pdf" => new PdfDocument(),
            "word" => new WordDocument(),
            _ => throw new ArgumentException("Invalid document type", nameof(type)),
        };
    }
}