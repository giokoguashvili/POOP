using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMath<T>
    {
        T Sum(T a, T b);
    }


    public class Math<T>
    {
        public Func<T, T, T> Sum { get; }

        public Math(Func<T, T, T> sum)
        {
            Sum = sum;
        }
    }

    public static class PolymorphismWithDictionary
    {
        public static T Sum<T>(Math<T> dMath, T a, T b)
        {
            return dMath.Sum(a, b);
        }
        public static void Run()
        {
            var dMath = new Math<int>((a, b) => a + b);

            Sum(dMath, 1, 2);
        }
    }
}
