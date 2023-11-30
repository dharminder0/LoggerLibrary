using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLoggerLib.Model {
    public class SQLConfigSinkModel {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
        public string LogLevelColumnName { get; set; } = "LogLevel";
        public string MessageColumnName { get; set; } = "Message";
        public string NamespaceColumnName { get; set; } = "Namespace";
    }
}
