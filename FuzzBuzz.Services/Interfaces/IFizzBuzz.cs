﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Services.Interfaces
{
    public interface IFizzBuzz
    {
        Task<List<string>> GetFizzBuzz(string[] arrayValues);
    }
}
