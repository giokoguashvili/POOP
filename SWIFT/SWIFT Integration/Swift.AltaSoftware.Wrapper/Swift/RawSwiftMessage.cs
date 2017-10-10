using Swift.Infrastructure.Infrastructure.Box.Abstract;
using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class RawSwiftMessage : Mandatory<string>
    {
        private readonly string _rawSwiftMessage;

        public RawSwiftMessage(string rawSwiftMessage)
        {
            _rawSwiftMessage = rawSwiftMessage;
        }
        public override IMandatory<string> Content()
        {
            return new Mandator<string>(_rawSwiftMessage);
        }
    }
}