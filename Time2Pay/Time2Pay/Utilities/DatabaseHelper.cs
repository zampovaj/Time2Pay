using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Time2Pay.Utilities
{
    internal class DatabaseHelper
    {
        private readonly SQLiteConnection _connection;
        private readonly TableHelper _tableHelper;

        public DatabaseHelper()
        {
            var database = new Database();
            _connection = new SQLiteConnection(database.ConnectionString);
            _tableHelper = new TableHelper(_connection);
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            try
            {
                _connection.Open();
                Console.WriteLine("Connected to the database.");

                // Enable foreign key constraints
                using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", _connection))
                {
                    pragmaCmd.ExecuteNonQuery();
                    Console.WriteLine("Foreign key constraints enabled.");
                }

                // Create tables
                CreateTables();

                Console.WriteLine("Tables initialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database initialization: {ex.Message}");
            }
        }

        private void CreateTables()
        {
            _tableHelper.CreateTable(TableNames.Hours, $@"
        CREATE TABLE IF NOT EXISTS {TableNames.Hours} (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT NOT NULL,
            StartTime TEXT NOT NULL,
            EndTime TEXT NOT NULL,
            Claimed INTEGER DEFAULT 0,
            SalaryId INTEGER NOT NULL,
            FOREIGN KEY (SalaryId) REFERENCES {TableNames.Salary}(Id)
        );");

            _tableHelper.CreateTable(TableNames.Salary, $@"
        CREATE TABLE IF NOT EXISTS {TableNames.Salary} (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartDate TEXT NOT NULL,
            EndDate TEXT NOT NULL,
            PreTaxSalary REAL NOT NULL,
            PostTaxSalary REAL NOT NULL,
            GasExpenses REAL DEFAULT 0,
            Total REAL DEFAULT 0
        );");

            _tableHelper.CreateTable(TableNames.Gas, $@"
        CREATE TABLE IF NOT EXISTS {TableNames.Gas} (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT NOT NULL,
            GasExpenses REAL NOT NULL,
            VehicleId INTEGER NOT NULL,
            SalaryId INTEGER NOT NULL,
            FOREIGN KEY (SalaryId) REFERENCES {TableNames.Salary}(Id)
        );");

            _tableHelper.CreateTable(TableNames.Multipliers, $@"
        CREATE TABLE IF NOT EXISTS {TableNames.Multipliers} (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Value REAL NOT NULL
        );");

            _tableHelper.CreateTable(TableNames.Settings, $@"
        CREATE TABLE IF NOT EXISTS {TableNames.Settings} (
            HourlyWage REAL NOT NULL,
            TaxRate REAL NOT NULL
        );");
        }

    }
}
