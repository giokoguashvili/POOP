using System;
using System.Linq;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //return new MissingLetter(
    //        new ConsecutiveLetters(
    //            ['a', 'b', 'c', 'd', 'f']
    //        )
    //    ).Result();
    //    }
    //}

    public static class MissingLetterSample
    {
        public static void Run()
        {
            Console.WriteLine(
                new MissingLetter(
                        new ConsecutiveLetters(
                            new[] { 'a', 'b', 'c', 'd', 'f' }
                        )
                 ).Result()
            );

            Console.ReadLine();
        }
    }
    public class MissingLetter
    {
        public ConsecutiveLetters _consecutiveLetters;
        public MissingLetter(ConsecutiveLetters consecutiveLetters)
        {
            _consecutiveLetters = consecutiveLetters;
        }

        private char Letter()
        {
            var ASCII = _consecutiveLetters.AsASCIIArray();
            var prev = ASCII.First();
            foreach (var code in ASCII)
            {
                if (code - prev == 2)
                {
                    return Convert.ToChar(prev + 1);
                }
                prev = code;
            }
            return Convert.ToChar(prev);
        }
        public char Result()
        {
            var result = this.Letter();
            if (_consecutiveLetters.IsUpper())
            {
                result = Convert.ToChar(result.ToString().ToUpper());
            }
            return result;
        }
    }

    public class ConsecutiveLetters
    {
        private char[] _letters;
        public ConsecutiveLetters(char[] letters)
        {
            _letters = letters;
        }
        public ushort[] AsASCIIArray()
        {
            return _letters
                .Select(l => Convert.ToUInt16(l))
                .ToArray();
        }

        public bool IsUpper()
        {
            var firstLetter = _letters.First().ToString();
            return firstLetter.ToUpper() == firstLetter;
        }

    }
}
