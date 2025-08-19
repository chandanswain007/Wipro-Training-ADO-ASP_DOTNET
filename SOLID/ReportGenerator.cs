// [cite_start]// Class responsible only for generating the report content [cite: 17]
public class ReportGenerator
{
    public string Generate(IReportContent reportContent)
    {
        return reportContent.GetContent();
    }
}