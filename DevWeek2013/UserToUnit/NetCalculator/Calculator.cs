using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCalculator
{
    public class Calculator
    {
        private List<int> _numbers = new List<int>();
        public void EnterNumber(int value)
        {
            _numbers.Add(value);
        }

        public int Add()
        {
            //return 120;
            return _numbers.Sum();            
        }
    }
}
