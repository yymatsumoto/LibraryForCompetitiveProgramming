using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesForCompetitiveProgramming
{
    class PrimeNumber
    {
        //素因数のリスト
        //Hashsetだと遅かった？
        public static List<long> GetPrimeFactor(long max)
        {
            var primeList = new List<long>();

            for (long i = 2; i * i <= max; i++)
            {
                while (max % i == 0)
                {
                    primeList.Add(i);
                    max /= i;
                }
            }
            if (max > 1)
            {
                primeList.Add(max);
            }
            return primeList.Distinct().ToList();
        }


        //素因数の数
        public static int CountPrimeFactor(long max)
        {
            var primeList = new List<long>();

            for (long i = 2; i * i <= max; i++)
            {
                while (max % i == 0)
                {
                    primeList.Add(i);
                    max /= i;
                }
            }
            if (max > 1)
            {
                primeList.Add(max);
            }
            return primeList.Distinct().Count();
        }


    }

}