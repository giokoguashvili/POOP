using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Swift.Infrastructure.Infrastructure;
using Swift.AltaSoftware.Wrapper.Swift.Common;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class RawSwiftMessages : IEnumerable<string>
    {
        private readonly SwiftFile _rawSwiftFile;

        public RawSwiftMessages(SwiftFile rawSwiftFile)
        {
            _rawSwiftFile = rawSwiftFile;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new SplitedString(
                    _rawSwiftFile.Content(),
                    new SwiftMessageStartSymbols()
                )
                .Content()
                .Where(s => s.Length > 10)
                .SelectMany(s => new RawSwiftMessage(
                        String.Format(
                            "{0}{1}",
                            new SwiftMessageStartSymbols().Content().First(),
                            s
                        )
                    )
                )
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}