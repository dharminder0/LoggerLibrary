namespace CustomLoggerLib.Model
{
    public class LogMessageModel
    {
        public LogLevelEnum Level { get; private set; }
        public string Content { get; private set; }
        public string ClassNamespace { get; private set; }

        public LogMessageModel(LogLevelEnum level, string content, string classNamespace)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Message content cannot be null or whitespace.", nameof(content));
            }

            Level = level;
            Content = content;
            ClassNamespace = classNamespace;
        }
    }
}
