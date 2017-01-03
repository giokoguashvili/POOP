using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public static class SpinedWordsSaple
    {
        public static void Run()
        {
            var sentence = "";
            Console.WriteLine(
                new Sentence(
                    new SpinedWords(
                        new Sentence(
                            sentence
                        ).Words()
                    )
                ).AsText()
            );
        }
    }


    public interface IWord
    {
        int Length();
        IWord Reverse();
        string AsText();
    }

    public class Word : IWord
    {
        private readonly string _str;
        public Word(string str) { _str = str; }
        public int Length() { return _str.Length; }
        public string AsText() { return _str; }
        public IWord Reverse()
        {
            var reversedStr = new String(_str.Reverse().ToArray());
            return new Word(reversedStr);
        }
    }

    public interface ISentence
    {
        IWords Words();
        string AsText();
    }

    public class Sentence : ISentence
    {
        private IWords _words;

        public Sentence(IWords words) { _words = words; }
        public Sentence(string str)
          : this(new Words(str.Split(' '))) { }

        public string AsText()
        {
            return String.Join(" ", _words.List().Select(word => word.AsText()));
        }
        public IWords Words()
        {
            return _words;
        }
    }

    public interface IWords
    {
        List<IWord> List();
    }

    public class Words : IWords
    {
        private readonly string[] _strs;
        public Words(string[] strs) { _strs = strs; }
        public List<IWord> List()
        {
            return _strs
                    .Select(str => new Word(str))
                    .ToList<IWord>();
        }
    }

    public class SpinedWords : IWords
    {
        private readonly IWords _words;
        public SpinedWords(IWords words) { _words = words; }
        public List<IWord> List()
        {
            return _words
                .List()
                .Select(word => word.Length() < 5 ? word : word.Reverse())
                .ToList<IWord>();
        }
    }
}
