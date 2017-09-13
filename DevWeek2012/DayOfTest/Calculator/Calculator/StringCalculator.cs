using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(numbers))
                return 0;
            return int.Parse(numbers);
        }

        protected int DumbMethod()
        {
            return 1;
        }

        internal int AnotherDumbMethod()
        {
            return 1;
        }
    }
}
