using System;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppMobyDick
{
    class Program
    {
        private const string Map = @"c:\tmp\MobyDick.xml";

        static async Task Main(string[] args)
        {
            FolderCheck(@"c:\tmp");
            var data = await LoadData();
            XmlCreater(data);
        }

        private static void FolderCheck(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void XmlCreater(string data)
        {
            var orderedWords = data.Split(' ').GroupBy(x => x).Select(x => new
                                        {
                                            Word = x.Key,
                                            Count = x.Count()
                                        }).OrderByDescending(x => x.Count).ToList();

            
            XDocument doc = new XDocument();
            XElement rootElement = new XElement("words");
            orderedWords.ForEach(i =>
            {
                var element = new XElement("word",
                    new XAttribute("text", i.Word),
                    new XAttribute("count", i.Count));
                rootElement.Add(element);
            });
            doc.Add(rootElement);
            doc.Save(Map);
        }

        public static async Task<string> LoadData()
        {
            string data;
            const string uri = "http://www.gutenberg.org/files/2701/2701-0.txt";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(uri))
            using (HttpContent content = response.Content)
            {
                data = await content.ReadAsStringAsync();
                if (data == null)
                    throw new Exception();
            }
            return data;
        }
    }
}
