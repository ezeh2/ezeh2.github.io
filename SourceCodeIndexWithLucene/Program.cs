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
            Directory.Delete(indexPath, true);
            if (!Directory.Exists(indexPath))
            {                
                Directory.CreateDirectory(indexPath);
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

            TilsiterSearcher tilsiterSearcher = new TilsiterSearcher(indexPath);
            tilsiterSearcher.Open();
            using (TextWriter tw = new TextWriter())
            {
                tilsiterSearcher.Search("class", tw);
            }
        }
    }
}
