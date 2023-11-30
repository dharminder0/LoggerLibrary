using CustomLoggerLib.Model;

namespace CustomLoggerLib.Service.Abstract
{
    public interface ILogSinkService
    {
        void Log(LogMessageModel message);
    }

}
