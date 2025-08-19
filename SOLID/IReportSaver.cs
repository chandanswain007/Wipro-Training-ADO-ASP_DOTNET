// Defines the contract for saving a report
public interface IReportSaver
{
    void Save(string content, string filePath);
}