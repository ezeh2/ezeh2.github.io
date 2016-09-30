using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceCodeIndexWithLucene
{
    internal class TilsiterIndex : IDisposable
    {
        private Analyzer analyzer = new StandardAnalyzer(new Lucene.Net.Util.Version());
        private IndexWriter indexWriter;

        internal TilsiterIndex(string indexPath)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(indexPath);
            Directory directory = FSDirectory.Open(di);
            indexWriter = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
        }

        internal void Close()
        {
            indexWriter.Close();
        }

        public void Dispose()
        {
            this.Close();
        }

        internal void AddEntry(string filePath, int lineNumber, string line)
        {
            Document doc = new Document();
            doc.Add(new Field("file_path", filePath, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("line_number", lineNumber.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("line", line, Field.Store.YES, Field.Index.ANALYZED));
            indexWriter.AddDocument(doc);            
        }
    }
}
