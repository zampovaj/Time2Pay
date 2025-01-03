using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2Pay.Model
{
    internal class Gas
    {
        private int id;
        private int salaryId;
        private double cost;
        public DateTime Date { get; private set; }

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be negative.");
                id = value;
            }
        }
        public int SalaryId
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be negative.");
                id = value;
            }
        }
        public double Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cost cannot be negative");
                cost = value;
            }
    }
}
