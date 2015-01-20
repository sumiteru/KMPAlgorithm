using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    class KMP
    {
        public static List<int> Search(string pattern, string text)
        {
            List<int> result = new List<int>();
            int[] P = calculateArray(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = 0, j = 0;

            while(i <= n - m)
            {
                j = P[j];
                while ((j < m) && pattern[j].Equals(text[i + j]))
                    j++;

                if (j == m)
                    result.Add(i);

                i = i + Math.Max(1, j - P[j]);
            }

            return result;
        }

        public static int[] calculateArray(string pattern)
        {
            int t = 0;
            int[] array = new int[pattern.Length + 1];
            array[0] = 0;
            array[1] = 0;

            for (int i = 2; i <= pattern.Length; i++)
            {
                while ((t > 0) && (pattern[t] != pattern[i - 1]))
                    t = array[t];

                if (pattern[t].Equals(pattern[i - 1]))
                    t++;

                array[i] = t;
            }

            return array;
        }
    }
}
