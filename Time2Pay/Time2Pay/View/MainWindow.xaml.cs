using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Time2Pay.Utilities;

namespace Time2Pay.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                // Initialize the database connection and tables
                DatabaseHelper databaseHelper = new DatabaseHelper();

                // You can also add some log or UI updates to show the user the process
                MessageBox.Show("Database Initialized Successfully!");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the initialization
                MessageBox.Show($"Error initializing the database: {ex.Message}");
            }
        }
    }
}
