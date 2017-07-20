using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var strings = new List<string>() {"abc", "bac", "abc", "d", "et", "d", "et"};
            //StringsWithIdenticalLetters



            WriteLine(
                new ResultView(
                    new CoincidingStringsIndexes(
                        new StringsWithIdenticalLetters(
                            new StringsWithSortedLetters(strings)
                        ),
                        new StringsWithSortedLetters(strings)
                    )
                )
            );
           
            var account = new Account(100);
            WriteLine(
                    account.Balance()
                );

            account.Deposit(50);
            WriteLine(
                    account.Deposit(200).Balance()
                );

            // new Application(
            //     new UserInterface(
            //         new DomainServices(
            //             new AccountService(),
            //             new UserService()
            //         )
            //     )
            // ).Run(Exit.Never);
        }
    }

    public class ResultView 
    {
        private readonly IEnumerable<IEnumerable<int>> _coincidingStringsIndexes;

        public ResultView(
                IEnumerable<IEnumerable<int>> coincidingStringsIndexes
            )
        {
            _coincidingStringsIndexes = coincidingStringsIndexes;
        }
        public override string ToString()
        {
            return
                String
                    .Join(
                        Environment.NewLine,
                        _coincidingStringsIndexes.Select(str => String.Join(",", str))
                    );
        }
    }
    public class CoincidingStringsIndexes : IEnumerable<IEnumerable<int>>
    {
        private readonly IEnumerable<string> _stringsWithIdenticalLetters;
        private readonly IEnumerable<string> _strings;

        public CoincidingStringsIndexes(
                IEnumerable<string> stringsWithIdenticalLetters,
                IEnumerable<string> strings
            )
        {
            _stringsWithIdenticalLetters = stringsWithIdenticalLetters;
            _strings = strings;
        }
        public IEnumerator<IEnumerable<int>> GetEnumerator()
        {
            return _stringsWithIdenticalLetters
                .Select(s => new CoincidingStringIndexes(_strings, s))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class CoincidingStringIndexes : IEnumerable<int>
    {
        private readonly IEnumerable<string> _strings;
        private readonly string _str;

        public CoincidingStringIndexes(
                IEnumerable<string> strings,
                string str
            )
        {
            _strings = strings;
            _str = str;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return Enumerable
                .Range(0, _strings.Count())
                .Zip(
                    _strings,
                    (i, s) => new {Index = i, Str = s}
                )
                .Where(z => z.Str.Equals(_str))
                .Select(z => z.Index)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class StringsWithIdenticalLetters : IEnumerable<string>
    {
        private readonly IEnumerable<string> _strings;

        public StringsWithIdenticalLetters(IEnumerable<string> strings)
        {
            _strings = strings;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _strings
                .GroupBy(
                    str => str,
                    str => str,
                    (str, strs) => new {Str = str, Count = strs.Count()}
                )
                .Where(g => g.Count > 1)
                .Select(g => g.Str)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class IntexedStrings : IEnumerable<Tuple<int, string>>
    {
        private readonly IEnumerable<string> _strings;

        public IntexedStrings(IEnumerable<string> strings)
        {
            _strings = strings;
        }
        public IEnumerator<Tuple<int, string>> GetEnumerator()
        {
            return Enumerable
                    .Range(0, _strings.Count())
                    .Zip(
                        _strings, 
                        (i, s) => new Tuple<int, string>(i, s)
                    )
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class StringsWithSortedLetters : IEnumerable<string>
    {
        private readonly IEnumerable<string> _strings;

        public StringsWithSortedLetters(IEnumerable<string> strings)
        {
            _strings = strings;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _strings
                .Select(s => new SortedString(s).Result())
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class SortedString
    {
        private readonly string _str;

        public SortedString(string str)
        {
            _str = str;
        }
        public string Result()
        {
            return String
                .Concat(
                    _str
                        .OrderBy(ch => ch)
                );

        }
    }
}