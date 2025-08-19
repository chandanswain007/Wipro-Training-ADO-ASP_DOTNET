using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Running Assignment 1: SOLID Principles ---");

        // [cite_start]// 1. Setup dependencies for the ReportService (Dependency Injection) [cite: 42]
        var reportGenerator = new ReportGenerator();
        var pdfFormatter = new PdfFormatter();
        var fileSaver = new FileSaver();

        // 2. Create the main service with its dependencies
        var reportService = new ReportService(reportGenerator, pdfFormatter, fileSaver);

        // 3. Create a standard sales report
        var salesReport = new SalesReport();
        reportService.CreateAndSaveReport(salesReport, "StandardSalesReport.txt");

        Console.WriteLine();

        // [cite_start]// 4. Demonstrate LSP: Use a derived class (DetailedSalesReport) where the base is expected [cite: 31]
        var detailedReport = new DetailedSalesReport();
        reportService.CreateAndSaveReport(detailedReport, "DetailedSalesReport.txt");

        Console.WriteLine("\n--- Assignment 1 Complete ---");


        Console.WriteLine("\n\n--- Running Assignment 2: Factory Pattern ---");

        // [cite_start]// 1. Use the factory to create a PDF document without knowing the concrete class [cite: 74]
        IDocument myPdf = DocumentFactory.CreateDocument("pdf");
        myPdf.Open();
        myPdf.Close();

        Console.WriteLine();

        // 2. Use the factory to create a Word document
        IDocument myWord = DocumentFactory.CreateDocument("word");
        myWord.Open();
        myWord.Close();

        Console.WriteLine("\n--- Assignment 2 Complete ---");
    }
}