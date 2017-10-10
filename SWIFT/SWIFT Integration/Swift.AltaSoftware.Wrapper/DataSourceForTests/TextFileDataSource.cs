using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace Swift.AltaSoftware.Wrapper.DataSourceForTests
{
    public class TextFileDataSource : DataAttribute
    {
        private readonly string _fileName;
        private string _testsDataSourceDirectoryName = "DataSourceForTests";
        public TextFileDataSource(string fileName)
        {
            _fileName = fileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var result = new List<object[]>();
            var filePath = $@"{Environment.CurrentDirectory}\{_testsDataSourceDirectoryName}\{_fileName}";
            using (var file = new FileStream(filePath, FileMode.Open))
            {
                result.Add(new[] {new StreamReader(file).ReadToEnd() });
            }
            return result;
        } 
    }
}