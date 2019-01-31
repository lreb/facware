using NetCore.Contract.Logger;
using NLog;

namespace NetCore.Service.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {

        }
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogFatal(string message)
        {
            logger.Fatal(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogTrace(string message)
        {
            logger.Trace(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
