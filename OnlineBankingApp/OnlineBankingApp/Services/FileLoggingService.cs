namespace OnlineBankingApp.Services
{
    public class FileLoggingService : ILoggingService
    {
        private readonly string _logFilePath = "bank_actions_log.txt";
        public void Log(string message)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}