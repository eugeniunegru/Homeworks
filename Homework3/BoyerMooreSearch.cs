using System;
using System.Runtime.CompilerServices;

class BoyerMooreSearch : IStringSearcher
{
    int pos;
    BoyerMooreSearch(string str,string pat)
    {
        this.pos=SearchString(str, pat);
    }
    public static int SearchString(string str, string pat)
    {
        List<int> retVal = new List<int>();
        int m = pat.Length;
        int n = str.Length;

        int[] badChar = new int[512];

        BadCharHeuristic(pat, m, ref badChar);
        int s = 0;
        while (s <= (n - m))
        {
            int j = m - 1;

            while (j >= 0 && pat[j] == str[s + j])
                --j;
            if (j < 0)
            {
                retVal.Add(s);
                s += (s + m < n) ? m - badChar[str[s + m]] : 1;
            }
            else
            {
                s += Math.Max(1, j - badChar[str[s + j]]);
            }
        }
        return retVal.ToArray()[0];
    }

    private static void BadCharHeuristic(string str, int size, ref int[] badChar)
    {
        int i;

        for (i = 0; i < 512; i++)
            badChar[i] = -1;

        for (i = 0; i < size; i++)
            badChar[(int)str[i]] = i;
    }

    public int 


}
