using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;
using System.Collections.Concurrent;

namespace CustomLoggerLib.Service.Concrete
{
    /// <summary>
    /// Represents a logger that can log messages with different levels.
    /// </summary>
    public class LoggerService : ILoggerService
    {
        private ConcurrentDictionary<LogLevelEnum, List<ILogSinkService>> _sinks = new ConcurrentDictionary<LogLevelEnum, List<ILogSinkService>>();
        public void AddSink(LogLevelEnum level, ILogSinkService sink)
        {

            _sinks.AddOrUpdate(level, new List<ILogSinkService> { sink },
                           (key, existingVal) =>
                           {
                               existingVal.Add(sink);
                               return existingVal;
                           });
        }

        /// <summary>
        /// Logs a message with a specific log level.
        /// </summary>
        /// <param name="message"></param>
        public void Log(LogMessageModel message)
        {
            if (_sinks.TryGetValue(message.Level, out var sinks))
            {
                foreach (var sink in sinks)
                {
                    sink.Log(message);
                }
            }
        }
    }
}
