using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace MuranoTest.Models
{
    public class YandexEngine : ISearchEngine
    {
        public async Task<SearchResult> SearchAsync(string SearchText)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var res = await client.GetStringAsync("https://yandex.ru/search/xml?user=nevaparts&key=03.102875578:688990b804a3eb3f384e7ad23a30378f&query=" + SearchText);

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(res);
                    XmlNodeList xmlRes = xmlDocument.GetElementsByTagName("group");

                    List<SearchResultItem> listResults = new List<SearchResultItem>();

                    if (xmlRes != null)
                        foreach (XmlNode x in xmlRes)
                        {
                            listResults.Add(new SearchResultItem { Header = x.SelectSingleNode("doc/title")?.InnerText, Link = x.SelectSingleNode("doc/domain")?.InnerText, Url = x.SelectSingleNode("doc/url")?.InnerText, Text = x.SelectSingleNode("doc/passages/passage")?.InnerText });
                        }

                    return new SearchResult { fullText = res, results = listResults };
                }
                catch (Exception ex)
                {
                    return new SearchResult { fullText = "YA ENGINE ERROR: " + ex.Data, results = null };
                }
            }
        }
    }


}
