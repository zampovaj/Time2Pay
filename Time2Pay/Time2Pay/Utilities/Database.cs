using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Data.SQLite;

namespace Time2Pay.Utilities
{
    public class Database
    {
        public string ConnectionString { get; private set; }

        public Database(string databaseName = "Time2Pay.db")
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);
            ConnectionString = $"Data Source={databasePath};Version=3;";
            Console.WriteLine($"Database Path: {databasePath}");
        }

        public void CreateDatabaseIfNotExist()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Time2Pay.db");
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine("Database created successfully.");
            }
            else
            {
                Console.WriteLine("Database file already exists.");
            }
        }
    }
}

