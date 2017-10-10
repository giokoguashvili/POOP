using System;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure
{
    public class SplitedString : IContent<string[]>
    {
        private readonly IMandatory<string> _str;
        private readonly IMandatory<string> _separator;

        public SplitedString(IMandatory<string> str, IMandatory<string> separator)
        {
            _str = str;
            _separator = separator;
        }
        public string[] Content()
        {
            return _str
                .First()
                .Split(new[] {_separator.First()}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}