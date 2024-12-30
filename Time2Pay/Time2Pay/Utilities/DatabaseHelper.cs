using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.IO;

namespace CarMate01.Classes
{
    internal class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CarMate.db");
            connectionString = $"Data Source={databasePath};Version=3;";
            Console.WriteLine($"Database Path: {databasePath}"); // Debug: Check where the database is being created.
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            try
            {
                // Check if the database file exists
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CarMate.db");
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                    Console.WriteLine("Database created successfully.");
                }
                else
                {
                    Console.WriteLine("Database file already exists.");
                }

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to the database.");

                    // Enable foreign key constraints
                    using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                    {
                        pragmaCmd.ExecuteNonQuery();
                        Console.WriteLine("Foreign key constraints enabled.");
                    }

                    // Create tables
                    ExecuteTableQuery(conn, "Hours", @"
                        CREATE TABLE IF NOT EXISTS Hours (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Claimed INTEGER DEFAULT 0
                    );");

                    ExecuteTableQuery(conn, "Salary", @"
                        CREATE TABLE IF NOT EXISTS Salary (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            StartDate TEXT NOT NULL,
                            EndDate TEXT NOT NULL,
                            PreTaxSalary REAL NOT NULL,
                            PostTaxSalary REAL NOT NULL,
                            GasExpenses REAL DEFAULT 0,
                            Total REAL DEFAULT 0
                        );");

                    ExecuteTableQuery(conn, "Gas", @"
                        CREATE TABLE IF NOT EXISTS Gas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT NOT NULL,
                            GasExpenses REAL NOT NULL,
                            VehicleId INTEGER NOT NULL,
                            SalaryId INTEGER NOT NULL,
                            FOREIGN KEY (SalaryId) REFERENCES Salary(Id)
                        );");

                    ExecuteTableQuery(conn, "Multipliers", @"
                        CREATE TABLE IF NOT EXISTS Multipliers (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Value REAL NOT NULL
                        );");

                    ExecuteTableQuery(conn, "Settings", @"
                        CREATE TABLE IF NOT EXISTS Settings (
                            HourlyWage REAL NOT NULL,
                            TaxRate REAL NOT NULL
                        );");

                    Console.WriteLine("Tables initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database initialization: {ex.Message}");
            }
        }

        private void ExecuteTableQuery(SQLiteConnection conn, string tableName, string query)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
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
