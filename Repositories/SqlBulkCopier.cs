using System;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public class SqlBulkCopier
    {
        public static void WriteToServer(string connectionString, DataTable dataTable, int timeoutSeconds)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                WriteToServer(connection, dataTable, timeoutSeconds);
                connection.Close();
            }
        }

        public static void WriteToServer(SqlConnection connection, DataTable dataTable, int timeoutSeconds)
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
            {
                sqlBulkCopy.DestinationTableName = dataTable.TableName;
                sqlBulkCopy.BulkCopyTimeout = 180;
                sqlBulkCopy.WriteToServer(dataTable);
            }
        }
    }
}
