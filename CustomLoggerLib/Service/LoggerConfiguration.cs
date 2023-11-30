using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;
using CustomLoggerLib.Service.Concrete;

namespace CustomLoggerLib.Service
{
    /// <summary>
    /// Represents a logger configuration that configure different log level to different type sink(text, console).
    /// </summary>
    public class LoggerConfiguration
    {
        public LoggerService Logger { get; private set; }

        public LoggerConfiguration()
        {
            Logger = new LoggerService();
        }

        /// <summary>
        /// Configure a log sink with different level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="sink"></param>
        public void Configure(LogLevelEnum level, ILogSinkService sink)
        {
            Logger.AddSink(level, sink);
        }
    }
}
