using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public static class CodeGenerator { 
        
        public static string RandomNumberSixDigitNumber()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

    }
}
