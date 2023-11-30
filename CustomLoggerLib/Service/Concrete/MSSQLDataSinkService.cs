using CustomLoggerLib.Model;
using CustomLoggerLib.Service.Abstract;
using System.Data.SqlClient;

namespace CustomLoggerLib.Service.Concrete {
    public class MSSQLDataSinkService : ILogSinkService {
        private readonly SQLConfigSinkModel _configSinkModel;

        public MSSQLDataSinkService(SQLConfigSinkModel config) {
            _configSinkModel = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Log(LogMessageModel message) {
            //using (var connection = new SqlConnection(_configSinkModel.ConnectionString)) {
            //    var command = connection.CreateCommand();
            //    command.CommandText = $@"INSERT INTO {_configSinkModel.TableName} 
            //                          ({_configSinkModel.LogLevelColumnName}, {_configSinkModel.MessageColumnName},{_configSinkModel.NamespaceColumnName}) 
            //                           VALUES (@LogLevel, @Message, @Namespace)";

            //    command.Parameters.AddWithValue("@LogLevel", message.Level.ToString());
            //    command.Parameters.AddWithValue("@Message", message.Content);
            //    command.Parameters.AddWithValue("@Namespace", message.ClassNamespace);
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}
        }
    }
}
