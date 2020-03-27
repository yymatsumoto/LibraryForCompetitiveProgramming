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


        ///<summary>昇順リストと値を渡すとその値が最初に出てくるインデックスを返す</summary>
        public static int LowerBound<T>(List<T> list, T value)
        {
            return LowerBound(list, value, Comparer<T>.Default);
        }

        ///<summary>昇順リストと値を渡すとその値が最初に出てくるインデックスを返す</summary>
        public static int LowerBound<T>(List<T> list, T value, Comparer<T> comparer)
        {
            var head = 0;
            var tail = list.Count - 1;

            //headがtailと同じ値になるタイミングがあり、そこでheadがtail+1になって出られる
            while (head <= tail)
            {
                var middle = head + (tail - head) / 2;

                switch (comparer.Compare(list[middle], value))
                {
                    case 1:
                        tail = middle - 1;
                        break;
                    case -1:
                        head = middle + 1;
                        break;
                    case 0:
                        tail = middle - 1;
                        break;
                }
            }
            return head;
        }
    }
}
