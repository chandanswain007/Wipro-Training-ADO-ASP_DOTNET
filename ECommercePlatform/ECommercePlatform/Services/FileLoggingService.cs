namespace ECommercePlatform.Services
{
    public class FileLoggingService : ILoggingService
    {
        private readonly string _logFilePath = "log.txt";

        public void Log(string message)
        {
            // Appends the message to the log file along with a timestamp.
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}