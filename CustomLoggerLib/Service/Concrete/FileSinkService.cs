using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;

namespace CustomLoggerLib.Service.Concrete
{
    public class FileSinkService : ILogSinkService
    {
        private string _filePath;

        public FileSinkService(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(LogMessageModel message)
        {
            try
            {
                string formatText = $"LogLevel : {message.Level}, Message: {message.Content}, Namespace: {message.ClassNamespace} -- {DateTime.Now.ToString()} {Environment.NewLine}";
                File.AppendAllText(_filePath, formatText);

            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO Exception in FileSink: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in FileSink: {ex.Message}");
            }
        }
    }
}
