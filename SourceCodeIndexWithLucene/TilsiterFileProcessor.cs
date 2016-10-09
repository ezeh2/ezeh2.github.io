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
        private List<string> searchPatterns;
        private int lineCount;

        internal TilsiterFileProcessor(string sourcePath, List<string> searchPatterns)
        {
            this.sourcePath = sourcePath;
            this.searchPatterns = searchPatterns;
        }

        internal void EnumerateAllLines(Action<string, int, string> action)
        {
            lineCount = 0;
            foreach (string searchPattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories);
                System.Console.WriteLine("{0} files with {1} found in {2} ", files.Length, searchPattern, sourcePath);
                foreach (string file in files)
                {
                    string allText = File.ReadAllText(file);
                    ProcessFile(action, file, allText);
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
