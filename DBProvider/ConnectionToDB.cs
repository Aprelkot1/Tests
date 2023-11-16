using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Tests.DBProvider
{
    internal class ConnectionToDB
    {
            static public string connectionString = "Server=.\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;";
    }
}
