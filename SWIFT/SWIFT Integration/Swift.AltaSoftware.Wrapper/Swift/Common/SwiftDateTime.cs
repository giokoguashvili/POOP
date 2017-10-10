using System;
using System.Linq;
using Swift.Infrastructure.Infrastructure.Box;
using Swift.Infrastructure.Infrastructure.Box.Concrete;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SwiftDateTime
    {
        private readonly string _dateTimeValue;

        public SwiftDateTime(string dateTimeValue)
        {
            _dateTimeValue = dateTimeValue;
        }

        public DateTime Value()
        {
            return new DateTime(
                        new YYYY(
                            new YY(_dateTimeValue)
                        ).Value(),
                        Int32.Parse(_dateTimeValue.Substring(2, 2)), // MM
                        Int32.Parse(_dateTimeValue.Substring(4, 2)) // MM
                   );
        }
    }

    public class YY
    {
        private readonly string _dateTimeValue;

        public YY(string dateTimeValue)
        {
            _dateTimeValue = dateTimeValue;
        }

        public int Value()
        {
            return Int32.Parse(_dateTimeValue.Substring(0, 2));
        }
    }

    public class YYYY
    {
        private readonly YY _year;

        public YYYY(YY year)
        {
            _year = year;
        }

        public int Value()
        {
            return new FirstOptional<int>(
                new Mapped<int, int>(
                    new Option<int>(
                        _year.Value(),
                        (yy) => yy >= 0 && yy <= 60
                    ),
                    yy => yy.First() + 2000
                ),
                new Mapped<int, int>(
                    new Option<int>(
                        _year.Value(),
                        (yy) => yy >= 80 && yy <= 99
                    ),
                    yy => yy.First() + 1900
                )
            ).First();
        }
    }
}