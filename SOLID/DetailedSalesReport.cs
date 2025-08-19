// [cite_start]// A derived class that can be substituted for its base class (LSP) [cite: 31]
public class DetailedSalesReport : SalesReport
{
    public new string GetContent()
    {
        return base.GetContent() + " This includes a detailed breakdown by region.";
    }
}