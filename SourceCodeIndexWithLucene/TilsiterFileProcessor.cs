using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceCodeIndexWithLucene
{
    internal class TilsiterFileProcessor
    {
        private string sourcePath;
        private List<AbstractTextConverter> textConverters;
        private int lineCount;

        internal TilsiterFileProcessor(string sourcePath, List<AbstractTextConverter> textConverters)
        {
            this.sourcePath = sourcePath;
            this.textConverters = textConverters;
        }

        internal void EnumerateAllLines(Action<string, int, string> action)
        {
            lineCount = 0;
            foreach (AbstractTextConverter textConverter in textConverters)
            {
                string[] filePaths = Directory.GetFiles(sourcePath, textConverter.SearchPattern, SearchOption.AllDirectories);
                System.Console.WriteLine("{0} files with {1} found in {2} ", filePaths.Length, textConverter.SearchPattern, sourcePath);
                foreach (string filePath in filePaths)
                {
                    string allText = textConverter.GetAllText(filePath);
                    ProcessFile(action, filePath, allText);
                }
            }
            System.Console.WriteLine("{0} lines of text added to index", lineCount);
        }

        private void ProcessFile(Action<string, int, string> action, string filePath, string fileContent)
        {
            using (StringReader sr = new StringReader(fileContent))
            {
                string line = null;
                int lineNumber = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    action(filePath, lineNumber, line);
                    lineNumber++;
                }
                lineCount += lineNumber;
            }
        }

    }
}
