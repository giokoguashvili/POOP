using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public interface IJsonFile : IContent<string> { }
    public class JsonFile : IJsonFile
    {
        private readonly string _filePath;

        public JsonFile(string filePath)
        {
            _filePath = filePath;
        }
        public string Content()
        {
            return System.IO.File.ReadAllText(_filePath);
        }
    }
}
