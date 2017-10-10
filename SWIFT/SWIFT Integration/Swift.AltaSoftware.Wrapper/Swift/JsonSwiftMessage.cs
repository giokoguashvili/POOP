using System.Xml;
using Newtonsoft.Json;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;

namespace Swift.AltaSoftware.Wrapper.Swift
{
    public class JsonSwiftMessage : IContent<string>
    {
        private readonly SwiftMessage _swiftMessage;

        public JsonSwiftMessage(SwiftMessage swiftMessage)
        {
            _swiftMessage = swiftMessage;
        }
        public string Content()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_swiftMessage.ToXmlRaw());
            return JsonConvert.SerializeXmlNode(doc);
        }
    }
}