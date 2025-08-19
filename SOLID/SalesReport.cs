// A concrete implementation of a report's content
public class SalesReport : IReportContent
{
    public string GetContent()
    {
        // In a real app, this would fetch data from a database
        return "Sales data for the last quarter.";
    }
}