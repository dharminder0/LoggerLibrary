using CustomLoggerLib;
using CustomLoggerLib.Model;
using CustomLoggerLib.Service;
using CustomLoggerLib.Service.Abstract;
using CustomLoggerLib.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerConsole
{
    public class Program {
        public static void Main(string[] args) {

            var dbSinkConfig = new SQLConfigSinkModel {
                ConnectionString ="Data Source=test.database.windows.net;Initial Catalog=Log-Shared-Db-Weu-Test;User Id= Db-User-Test-Acc;Password=M4cc7bbaqXTXj",        // "Your database connection string here",
                TableName = "LogEntries",
                LogLevelColumnName = "LogLevel",
                MessageColumnName = "Message",
                NamespaceColumnName = "Namespace",
            };

            // Register your logger as a singleton
            //webapi/Console Application with IOC pattern with CustomLoggerLib integration

            var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerService, LoggerService>(serviceProvider => {
                var loggerConfiguration = new LoggerConfiguration();
                loggerConfiguration.Configure(LogLevelEnum.ERROR, new FileSinkService("logfile.txt"));
                loggerConfiguration.Configure(LogLevelEnum.INFO, new ConsoleSinkService());
                loggerConfiguration.Configure(LogLevelEnum.ERROR, new MSSQLDataSinkService(dbSinkConfig));
                return loggerConfiguration.Logger;
            })
            .BuildServiceProvider();

            ////Simple Console Application with CustomLoggerLib integration
            //LoggerConfiguration config = new LoggerConfiguration();
            //config.Configure(LogLevel.ERROR, new FileSink("logfile.txt"));
            //config.Configure(LogLevel.INFO, new ConsoleSink());
            //Logger logger = config.Logger;

            var logger = serviceProvider.GetService<ILoggerService>();
            logger.Log(new LogMessageModel(LogLevelEnum.INFO, "LoggerConsole info message", "LoggerConsole"));
            logger.Log(new LogMessageModel(LogLevelEnum.ERROR, "LoggerConsole error message", "LoggerConsole"));

        }
    }
}