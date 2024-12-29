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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Time2Pay.Controls
{
    /// <summary>
    /// Interaction logic for DaySchedule.xaml
    /// </summary>
    public partial class DaySchedule : UserControl
    {
        public string DayName
        {
            get { return (string)GetValue(DayNameProperty); }
            set { SetValue(DayNameProperty, value); }
        }

        public static readonly DependencyProperty DayNameProperty =
            DependencyProperty.Register("DayName", typeof(string), typeof(DaySchedule));

        public DaySchedule()
        {
            InitializeComponent();
            DataContext = this; // Set the data context to the user control itself
        }
    }
}
