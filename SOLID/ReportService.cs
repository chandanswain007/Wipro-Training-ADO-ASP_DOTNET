// This high-level class depends on abstractions (interfaces), not on low-level concrete classes
public class ReportService
{
    private readonly ReportGenerator _generator;
    private readonly IReportFormatter _formatter;
    private readonly IReportSaver _saver;

    // Dependencies are injected via the constructor (Dependency Injection)
    public ReportService(ReportGenerator generator, IReportFormatter formatter, IReportSaver saver)
    {
        _generator = generator;
        _formatter = formatter;
        _saver = saver;
    }

    public void CreateAndSaveReport(IReportContent reportContent, string filePath)
    {
        string content = _generator.Generate(reportContent);
        _formatter.Format(content);
        _saver.Save(content, filePath);
    }
}