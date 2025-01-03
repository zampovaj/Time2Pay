using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;

namespace Time2Pay.Utilities
{
    public class TableHelper
    {
        private readonly SQLiteConnection _connection;

        public TableHelper(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void CreateTable(string tableName, string query)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Table '{tableName}' created or already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating table '{tableName}': {ex.Message}");
            }
        }
    }
}

