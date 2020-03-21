using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesForCompetitiveProgramming
{
    class Mod
    {
        public static long ModFactorial(long n, long mod)
        {
            var result = n;

            if (n > 0)
            {

                while (n > 1)
                {
                    n--;
                    result *= n;
                    result %= mod;
                }

                return result;
            }
            else
            {
                //マイナス時も1でいいのか？
                return 1;
            }
        }

        public static long ModPow(long b, long pow, long mod)
        {
            if (pow == 1)
            {
                return b % mod;
            }

            long n = ModPow(b, pow / 2, mod) % mod;

            if (pow % 2 == 0)
            {
                return (n * n) % mod;
            }
            else
            {
                return (b * ((n * n) % mod)) % mod;
            }
        }

        public static long ModCombination(long sum, long num, long mod)
        {
            long x = 1;
            for (var i = 0; i < num; i++)
            {
                x *= (sum - i);
                x %= mod;
            }

            var result = (x * (ModPow(ModFactorial(num, mod), 1000000005, 1000000007))) % 1000000007;

            return result;
        }
    }
}
