using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;
using System.IO;

namespace Time2Pay.Utilities
{
    //Base class for all repository classes
    //Helps intiate database connection

    //EXAMPLE OF USE:

    //namespace Time2Pay.Repositories
    //{
    //    internal class SalaryRepository : DatabaseConnection
    //    {
    //        public void AddSalary(string startDate, string endDate, double preTax, double postTax)
    //        {
    //            using (var conn = GetConnection())
    //            {
    //                string query = @"
    //            INSERT INTO Salary (StartDate, EndDate, PreTaxSalary, PostTaxSalary) 
    //            VALUES (@StartDate, @EndDate, @PreTaxSalary, @PostTaxSalary)";

    //                using (var cmd = new SQLiteCommand(query, conn))
    //                {
    //                    cmd.Parameters.AddWithValue("@StartDate", startDate);
    //                    cmd.Parameters.AddWithValue("@EndDate", endDate);
    //                    cmd.Parameters.AddWithValue("@PreTaxSalary", preTax);
    //                    cmd.Parameters.AddWithValue("@PostTaxSalary", postTax);
    //                    cmd.ExecuteNonQuery();
    //                }
    //            }
    //        }
    //    }
    //}

    internal abstract class DatabaseConnection
    {
        protected readonly string connectionString;

        public DatabaseConnection()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Time2Pay.db");
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        protected SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();

            using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
            {
                cmd.ExecuteNonQuery();
            }

            return conn;
        }
    }
}

