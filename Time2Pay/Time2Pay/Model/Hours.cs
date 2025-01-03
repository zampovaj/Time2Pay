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
            private int id;
            public DateTime Date { get; private set; }
            public TimeSpan StartTime { get; private set; }
            public TimeSpan EndTime { get; private set; }
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

}
