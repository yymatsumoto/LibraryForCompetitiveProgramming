﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesForCompetitiveProgramming
{
    class Calculation
    {
        public static long Factorial(long n)
        {
            var result = n;

            if (n > 0)
            {

                while (n > 1)
                {
                    n--;
                    result *= n;
                }

                return result;
            }
            else
            {
                //マイナス時も1でいいのか？
                return 1;
            }
        }

        public static long AddOneToN(long n)
        {
            long result = 0;
            result = (n * (n + 1)) / 2;
            return result;
        }

        public static long Combination(long all, long n)
        {
            return Factorial(all) / Factorial(n) * Factorial(all - n);
        }
    }
}
