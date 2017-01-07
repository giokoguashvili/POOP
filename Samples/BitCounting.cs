using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{

    public static class BitCountingSample
    {
        public static void Run()
        {
            Console.WriteLine(
                new BitCounting(
                    new UnsignedInteger(
                        0
                    )
                ).Result()
            );
            Console.ReadLine();
        }
    }

    public class BitCounting
    {
        private UnsignedInteger _unsignedInteger;
        public BitCounting(UnsignedInteger unsignedInteger)
        {
            _unsignedInteger = unsignedInteger;
        }
        public int Result()
        {
            return _unsignedInteger.Bytes().Sum(i => i);
        }
    }

    public class UnsignedInteger
    {
        private uint _uint;
        public UnsignedInteger(uint uinteger)
        {
            _uint = uinteger;
        }

        public byte[] Bytes()
        {
            return Enumerable
                .Range(0, 32)
                .Select(index => new { Ind = index, Val = _uint })
                .Select(item =>
                {
                    if ((item.Val & (1 << item.Ind)) != 0)
                        return (byte)1;
                    return (byte)0;
                })
                .ToArray();
        }
    }
}
