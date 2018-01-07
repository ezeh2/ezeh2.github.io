using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace tokenizer
{

    public class ParsingWithHtmlAgilityPack
    {
        public void ParseShortHtml()
        {
            /*
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://www.mufap.com.pk/payout-report.php?tab=01");
            */

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(@"sxsx<a a='1' b=""x"">xxsx</a>sxsx");
            HtmlNode htmlNode = doc.DocumentNode;
            HtmlNode htmlElement = htmlNode.Element("a");

            /*
            List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='mydata']")
                        .Descendants("tr")
                        .
                        .Where(tr=>tr.Elements("td").Count()>1)
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();
                         */
        }
    }

}