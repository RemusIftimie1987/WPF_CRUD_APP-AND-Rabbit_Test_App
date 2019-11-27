using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Lab_08_TDD_Collections
{
     public class TestCollections
    {
        public static int ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e)
        {
            
            List<int> ls = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var result = 0;

            a += 5;
            b += 5;
            c += 5;
            d += 5;
            e += 5;
            int[] num = { a,b,c,d,e };

            for (int i = 0; i < num.Length; i++)
            {
                var item = num[i] * num[i];
                ls.Add(item);
            }

            for (int i = 0; i < ls.Count; i++)
            {
                var item2 = ls[i] - 10;
                dict.Add(i, item2);
            }

            return dict.Values.Sum();

            #region v02 needs small adjustments
            //foreach (var item in num)
            //{
            //    num[item] = item * item;
            //    ls.Add(num[item]);
            //    dict.Add(item + 1, ls[item] - 10);
            //}
            //foreach (var item in dict)
            //{
            //    result = dict.Sum(x => x.Value);
            //}
            //return result;
            #endregion
        }
    }
}
