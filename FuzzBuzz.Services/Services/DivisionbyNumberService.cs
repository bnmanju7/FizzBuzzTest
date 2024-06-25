using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz.Services.Interfaces;

namespace FizzBuzz.Services
{
    public class DivisionbyNumberService : IDivionbyNumber
    {
        public bool IsDivisibleByNumber(int number, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Divisor cannot be zero");
            }
            return number % divisor == 0;
        }
    }
}
