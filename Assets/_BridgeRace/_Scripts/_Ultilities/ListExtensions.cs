using System;
using System.Collections.Generic;

public static class ListExtensions
{
    #region --- Fields ---

    private static Random rnd = new Random();

    #endregion

    #region --- Methods ---

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    #endregion
}
