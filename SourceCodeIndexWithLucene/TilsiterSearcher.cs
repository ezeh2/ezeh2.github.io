using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceCodeIndexWithLucene
{
    internal class TilsiterSearcher : IDisposable
    {
        private string indexPath;
        private IndexReader ireader;
        private IndexSearcher isearcher;
        private Analyzer analyzer = new StandardAnalyzer(new Lucene.Net.Util.Version());
        internal TilsiterSearcher(string indexPath)
        {
            this.indexPath = indexPath;
        }

        internal void Open()
        {
             System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(indexPath);
             Directory directory = FSDirectory.Open(di);
             ireader = DirectoryReader.Open(directory, true);
             isearcher = new IndexSearcher(ireader);
        }

        internal void Search(string text, System.IO.TextWriter textWriter)
        {
            TopDocs topDocs = GetTopDocs(text);

            // Iterate through the results:
            for (int i = 0; i < topDocs.ScoreDocs.Length; i++)
            {
                Document hitDoc = isearcher.Doc(topDocs.ScoreDocs[i].Doc);
                textWriter.WriteLine("{0}", hitDoc.GetField("line").StringValue);
            }
            System.Console.WriteLine($@"{topDocs.ScoreDocs.Length} lines matching search term ""{text}"" found and written to search_result.txt");
        }

        private TopDocs GetTopDocs(string text)
        {
            // Parse a simple query that searches for "text":
            QueryParser parser = new QueryParser(new Lucene.Net.Util.Version(), "line", analyzer);
            Query query = parser.Parse(text);
            // ScoreDoc[] hits = isearcher.Search(query, null, 1000).ScoreDocs;
            TopDocs topDocs = isearcher.Search(query, null, 1000);
            return topDocs;
        }

        public void Dispose()
        {
 	        this.Close();
        }

        private void Close()
        {
            ireader.Close();
            isearcher.Close();
        }
    }
}
