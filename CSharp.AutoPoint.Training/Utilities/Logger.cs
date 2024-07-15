using Serilog;

namespace CSharp.AutoPoint.Training.Utilities
{
    public class Logger
    {
        public Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void LogInformation(string message)
        {
            Log.Information(message);
        }

        public void LogDebug(string message)
        {
            Log.Debug(message);
        }
        public void LogWarning(string message)
        {
            Log.Warning(message);
        }

        public void LogError(string message)
        {
            Log.Error(message);
        }
    }
}
