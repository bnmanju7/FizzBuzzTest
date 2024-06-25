using FizzBuzz.Services.Constants;
using FizzBuzz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzz
    {
        private readonly IDivionbyNumber _divionbyNumber;
        public FizzBuzzService(IDivionbyNumber divionbyNumber) 
        { 
            _divionbyNumber = divionbyNumber;
        }
        public Task<List<string>> GetFizzBuzz(string[]? arrayValues)
        {
            var results = new List<string>();

            if (arrayValues?.Length > 0)
            {
                foreach (var item in arrayValues)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        results.Add(globalConstants.InvalidItem);
                        continue;
                    }

                    if (!int.TryParse(item, out int num))
                    {
                        results.Add(globalConstants.InvalidItem);
                        continue;
                    }

                    bool divisibleBy3 = _divionbyNumber.IsDivisibleByNumber(num, 3);
                    bool divisibleBy5 = _divionbyNumber.IsDivisibleByNumber(num, 5);

                    if (divisibleBy3 && divisibleBy5)
                    {
                        results.Add(globalConstants.FizzBuzz);
                    }
                    else if (divisibleBy3)
                    {
                        results.Add(globalConstants.Fizz);
                    }
                    else if (divisibleBy5)
                    {
                        results.Add(globalConstants.Buzz);
                    }
                    else
                    {
                        results.Add($"{globalConstants.Number}{num}{globalConstants.NotDivisibleBy3Or5}");
                    }
                }
            }

            return Task.FromResult(results);
        }
    }
}
