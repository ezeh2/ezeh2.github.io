using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SourceCodeIndexWithLucene
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = SourceCodeIndexWithLucene.Properties.Settings.Default.SourcePath;
            string indexPath = SourceCodeIndexWithLucene.Properties.Settings.Default.IndexPath;
            string searchResultPath = SourceCodeIndexWithLucene.Properties.Settings.Default.SearchResultPath;
            bool buildIndex = false;
            bool deleteIndex = false;

            if (args.Contains("-build_index"))
            {
                buildIndex = true;
            }
            if (args.Contains("-delete_index"))
            {
                deleteIndex = true;
            }
            if (deleteIndex)
            {
                Directory.Delete(indexPath, true);
            }

            if (buildIndex)
            {
                if (!Directory.Exists(indexPath))
                {
                    Directory.CreateDirectory(indexPath);
                }
                else
                {
                    throw new ApplicationException("index already exists, please use -delete_index first");
                }

                TilsiterFileProcessor fileProcessor = new TilsiterFileProcessor(sourcePath, "*.cs");
                using (TilsiterIndex index = new TilsiterIndex(indexPath))
                {
                    fileProcessor.EnumerateAllLines(
                        (filePath, lineNumber, line) =>
                        {
                            index.AddEntry(filePath, lineNumber, line);
                        }
                    );
                }
            }

            if (!Directory.Exists(indexPath))
            {
                throw new ApplicationException("no index exists, please use -build_index first");
            }

            string search_term = null;
            if (args.Length == 1)
            {
                search_term = args[0];
            }

            TilsiterSearcher tilsiterSearcher = new TilsiterSearcher(indexPath);
            tilsiterSearcher.Open();
            using (TextWriter tw = File.CreateText(searchResultPath))
            {
                tilsiterSearcher.Search(search_term, tw);
            }
        }
    }
}
