using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;
using CustomLoggerLib.Service.Concrete;

namespace CustomLoggerLib.Service
{
    public class LoggerConfiguration
    {
        public LoggerService Logger { get; private set; }

        public LoggerConfiguration()
        {
            Logger = new LoggerService();
        }

        public void Configure(LogLevelEnum level, ILogSinkService sink)
        {
            Logger.AddSink(level, sink);
        }
    }
}
