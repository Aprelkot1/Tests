using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DBProvider
{
    internal class DBTableCreator: ConnectionToDB
    {
        public async Task TableCreator(string sqlCommandText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlCommandText;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
