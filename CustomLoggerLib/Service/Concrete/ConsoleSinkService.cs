using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;

namespace CustomLoggerLib.Service.Concrete
{
    public class ConsoleSinkService : ILogSinkService
    {
        public void Log(LogMessageModel message)
        {
            Console.WriteLine($@"LogLevel : {message.Level}, Message: {message.Content}, Namespace: {message.ClassNamespace}");
        }
    }
}
