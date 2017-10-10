using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public interface IAsSwiftMessage<out TOut> : IAsSwiftMessage
    {
        SwiftMessage Raw();
    }

    public interface IAsSwiftMessage
    {
        IContent<string> BankLTAdress();
    }
}
