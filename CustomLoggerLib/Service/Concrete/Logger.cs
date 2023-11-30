using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;
using System.Collections.Concurrent;

namespace CustomLoggerLib.Service.Concrete
{
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
