using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForCompetitiveProgramming
{
    class BinarySearchTree
    {

        public int BinarySearch<T>(T[] array, T num) where T : IComparable<T>
        {
            var head = 0;
            var tail = array.Length - 1;

            while (head < tail)
            {
                var middle = head + (tail - head) / 2;

                switch (num.CompareTo(array[middle]))
                {
                    case 1:
                        head = middle - 1;
                        break;
                    case -1:
                        tail = middle - 1;
                        break;
                    case 0:
                        return middle;
                }
            }
            return -1;
        }


    }
}
