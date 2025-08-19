using Serilog;

namespace SecureAppl
{
    public static class Logger
    {
        // This method was missing or incorrect
        public static ILogger GetLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}