using Swift.Infrastructure.Infrastructure.Box.Concrete;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class SwiftFile
    {
        public string RawContent { private get; set; }

        public SwiftFile(string swiftFileRawContent)
        {
            RawContent = swiftFileRawContent;
        }
        public IMandatory<string> Content()
        {
            return new Mandator<string>(RawContent);
        }
    }
}