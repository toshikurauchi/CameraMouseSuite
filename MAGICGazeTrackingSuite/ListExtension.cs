using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGICGazeTrackingSuite
{
    public static class ListExtension
    {
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            // Create a copy of the input, and sort the copy
            TSource[] temp = source.ToArray();
            Array.Sort(temp, (o1, o2) => selector(o1).CompareTo(selector(o2)));

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                double a = selector(temp[count / 2 - 1]);
                double b = selector(temp[count / 2]);
                return (a + b) / 2;
            }
            else
            {
                // count is odd, return the middle element
                return selector(temp[count / 2]);
            }
        }
        public static TSource Argmin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source.Count() == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            return source.Aggregate((curmin, x) => (curmin == null || selector(x) < selector(curmin) ? x : curmin));
        }
    }
}
