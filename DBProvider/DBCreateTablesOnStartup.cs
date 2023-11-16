using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tests.DBProvider
{
    internal class DBCreateTablesOnStartup
    {
        public static async void CreateTables()
        {
            try
            {
                DBTableCreator tc = new DBTableCreator();
                await tc.TableCreator("IF OBJECT_ID(N'dbo.Tests', N'U') IS NULL CREATE TABLE Tests (Id INT PRIMARY KEY IDENTITY, TestName NVARCHAR(300) NOT NULL)");
                await tc.TableCreator("IF OBJECT_ID(N'dbo.Questions', N'U') IS NULL CREATE TABLE Questions (Id INT PRIMARY KEY IDENTITY,Test INT, Question NVARCHAR(300) NOT NULL,FOREIGN KEY (Test) REFERENCES Tests (Id) ON DELETE CASCADE)");
                await tc.TableCreator("IF OBJECT_ID(N'dbo.Answers', N'U') IS NULL CREATE TABLE Answers (Id INT PRIMARY KEY IDENTITY,Question INT, Answer NVARCHAR(300) NOT NULL, True INT, FOREIGN KEY (Question) REFERENCES Questions (Id) ON DELETE CASCADE)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
