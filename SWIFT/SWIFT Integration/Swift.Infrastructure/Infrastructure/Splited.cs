using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure
{
    public class Splited : IEnumerable<IOptional<string>>
    {
        private readonly IOptional<string> _text;
        private readonly IOptional<string> _separator;

        public Splited(string str, string separator) 
            : this(
                  String.IsNullOrEmpty(str) ? new Option<string>() : new Option<string>(str),
                  String.IsNullOrEmpty(separator) ? new Option<string>() : new Option<string>(separator))
        {}

        public Splited(IOptional<string> text, IOptional<string> separator)
        {
            _text = text;
            _separator = separator;
        }
        public IEnumerator<IOptional<string>> GetEnumerator()
        {
            return _text
                        .SelectMany(
                            t => _separator
                                .SelectMany(s => t.Split(new[] {s}, StringSplitOptions.None))
                                .Select(s => String.IsNullOrEmpty(s) ? new Option<string>() : new Option<string>(s))
                        ).GetEnumerator();
            //return _separator
            //            .SelectMany(
            //                s => _text
            //                    .Select(t => t.Split(new[] {s}, StringSplitOptions.None)
            //                    )
            //            );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}