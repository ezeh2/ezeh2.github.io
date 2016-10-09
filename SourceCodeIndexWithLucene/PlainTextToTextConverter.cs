using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceCodeIndexWithLucene
{
    public class PlainTextToTextConverter : AbstractTextConverter
    {
        public PlainTextToTextConverter(string searchPattern)
            : base(searchPattern)
        {            
        }

        public override string GetAllText(string filePath)
        {
            return  File.ReadAllText(filePath);
        }
    }
}
