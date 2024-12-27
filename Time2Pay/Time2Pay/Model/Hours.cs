using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2Pay.Model
{
    using System;

    namespace Time2Pay.Models
    {
        internal class Hours
        {
            // Private fields to store the data
            private int _id;
            private string _day;
            private string _startTime;
            private string _endTime;
            private double _hoursWorked;
            private decimal _earnings;

            // Public property for Id (getter and setter)
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            // Public property for Day
            public string Day
            {
                get { return _day; }
                set { _day = value; }
            }

            // Public property for StartTime
            public string StartTime
            {
                get { return _startTime; }
                set { _startTime = value; }
            }

            // Public property for EndTime
            public string EndTime
            {
                get { return _endTime; }
                set { _endTime = value; }
            }

            // Public property for HoursWorked
            public double HoursWorked
            {
                get { return _hoursWorked; }
                set { _hoursWorked = value; }
            }

            // Public property for Earnings
            public decimal Earnings
            {
                get { return _earnings; }
                set { _earnings = value; }
            }

            // Constructor
            public Hours(int id, string day, string startTime, string endTime, double hoursWorked, decimal earnings)
            {
                _id = id;
                _day = day;
                _startTime = startTime;
                _endTime = endTime;
                _hoursWorked = hoursWorked;
                _earnings = earnings;
            }

            // Override ToString() if needed to easily view or debug the object
            public override string ToString()
            {
                return $"Day: {Day}, StartTime: {StartTime}, EndTime: {EndTime}, Hours Worked: {HoursWorked}, Earnings: {Earnings:C}";
            }
        }
    }

}
