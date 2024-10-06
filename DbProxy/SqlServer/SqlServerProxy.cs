using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProxy.SqlServer
{
    public class SqlServerProxy : IDbProxy
    {
        private string connectionString;

        private SqlConnection _connection;

        public DbConnection connection { get => _connection; }
        public DbCommand command { get; }
        public DbDataAdapter adapter { get; }
        public DbCommandBuilder commandBuilder { get; }
        public SqlServerProxy(string connectionString)
        {
            this.connectionString = connectionString;
            _connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            commandBuilder = new SqlCommandBuilder((SqlDataAdapter)adapter); ;
        }

        public DbCommand BaseTablesCommand()
        {
            return new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", _connection);
        }
    }
}
