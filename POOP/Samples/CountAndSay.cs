using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class CountAndSay
    {

        //{:expected "111221" :arguments["three 1, then two 2's, then one 1"]}
        //{:expected "11" :arguments["two 1's"}
        //{:expected "21" :arguments["one 2, then one 1"]}
        //{:expected "1211" :arguments["one 1, then one 2, then two 1's"]}]
        public static void Run()
        {
            Console.WriteLine(
                new JoinedDigits(
                    new Digits(
                        new AloudNumbers(
                            new ParsedSentence(
                                "one 1, then one 2, then two 1's"
                            )
                        )
                    )
                ).AsString()
            );

            Console.ReadLine();
        }
    }

    public class JoinedDigits
    {
        private Digits _digits;
        public JoinedDigits(Digits digits)
        {
            _digits = digits;
        }

        public string AsString()
        {
            return _digits.AsList()
                .Select(d => d.AsString())
                .Aggregate(String.Empty, (prev, next) => { return prev += next; });
        }
    }
    public class ParsedSentence
    {
        private string _sentence;
        public ParsedSentence(string sentence)
        {
            _sentence = sentence;
        }
        public string Content()
        {
            return _sentence
                .Replace("then", String.Empty)
                .Replace("'s", String.Empty);
        }
    }

    public class AloudNumbers
    {
        private ParsedSentence _sentence;
        public AloudNumbers(ParsedSentence sentence)
        {
            _sentence = sentence;
        }
        public List<AloudNumber> AsList()
        {
            return _sentence
                .Content()
                .Split(',')
                .Select(n => new AloudNumber(n.Trim()))
                .ToList();
        }
    }

    public class AloudNumber
    {
        private string _str;
        public AloudNumber(string str)
        {
            _str = str;
        }

        public string NumberPart()
        {
            return _str.Split(' ')[1];
        }

        public string WordPart()
        {
            return _str.Split(' ')[0];
        }
    }

    public class Digits
    {
        private AloudNumbers _aloudNumbers;
        public Digits(AloudNumbers aloudNumbers)
        {
            _aloudNumbers = aloudNumbers;
        }
        public List<Digit> AsList()
        {
            return _aloudNumbers
                .AsList()
                .Select(n => new Digit(n))
                .ToList();
        }
    }

    public class Digit
    {
        private AloudNumber _aloudNumber;
        private Dictionary<string, int> _dictionary = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        public Digit(AloudNumber aloudNumber)
        {
            _aloudNumber = aloudNumber;
        }
        public string AsString()
        {
            var count = _dictionary[_aloudNumber.WordPart()];
            return Enumerable
                .Range(1, count)
                .Select(r => _aloudNumber.NumberPart())
                .Aggregate(String.Empty, (prev, next) => { return prev += next; });
        }
    }
}
