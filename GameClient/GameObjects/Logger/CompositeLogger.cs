using System.Collections.Generic;

namespace GameClient.GameObjects.Logger
{
    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> _loggers;

        public CompositeLogger(List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void LogMessage(string msg)
        {
            foreach (var logger in _loggers)
            {
                logger.LogMessage(msg);
            }
        }
    }
}