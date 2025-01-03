using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2Pay.Model
{
    internal class Salary
    {
        private int id;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Claimed { get; private set; }

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
    }
}
