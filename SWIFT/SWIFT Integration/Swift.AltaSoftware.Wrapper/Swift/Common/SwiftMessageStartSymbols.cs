using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.AltaSoftware.Wrapper.Swift.Common
{
    public class SwiftMessageStartSymbols : Mandatory<string>
    {
        private readonly string _symbols = "{1:";
        public override IMandatory<string> Content()
        {
            return new Mandator<string>(_symbols);
        }
    }
}