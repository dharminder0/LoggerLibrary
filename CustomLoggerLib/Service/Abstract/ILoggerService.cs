using CustomLoggerLib.Model;

namespace CustomLoggerLib.Service.Abstract
{
    public interface ILoggerService
    {
        void AddSink(LogLevelEnum level, ILogSinkService sink);
        void Log(LogMessageModel message);
    }
}