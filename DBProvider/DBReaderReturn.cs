using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
namespace Tests.DBProvider
{
    internal class DBReaderReturn : ConnectionToDB
    {
        public async Task<int> ReturnCount(string sqlCommandText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlCommandText;
                command.Connection = connection;
                int count = (int)await command.ExecuteScalarAsync();
                return count;
            }
        }
        public async Task<string> ToJson(string sqlCommandText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;
                XmlDocument xmlDoc;
                command.CommandText = sqlCommandText;
                command.Connection = connection;
                reader = command.ExecuteReader();
                // Convert the SqlDataReader to a DataTable
                var table = new System.Data.DataTable();
                table.Load(reader);
                // Convert the DataTable to JSON using Newtonsoft.Json
                string json = JsonConvert.SerializeObject(table);
                return json;
            }
        }
    }
}
