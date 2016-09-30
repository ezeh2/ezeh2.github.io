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
        private string searchPattern;

        internal TilsiterFileProcessor(string sourcePath, string searchPattern)
        {
            this.sourcePath = sourcePath;
            this.searchPattern = searchPattern;
        }

        internal void EnumerateAllLines(Action<string, int, string> action)
        {
            string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                string allText = File.ReadAllText(file);
                ProcessFile(action, file, allText);
            }
        }

        private static void ProcessFile(Action<string, int, string> action, string filePath, string fileContent)
        {
            using (StringReader sr = new StringReader(fileContent))
            {
                string line = null;
                int lineNumber = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    action(filePath, lineNumber, fileContent);
                    lineNumber++;
                }
            }
        }

    }
}
