using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceCodeIndexWithLucene
{
    public abstract class AbstractTextConverter
    {
        private string searchPattern;

        protected AbstractTextConverter(string searchPattern)
        {
            this.searchPattern = searchPattern;
        }

        public string SearchPattern            
        {
            get
            {
                return this.searchPattern;
            }
        }

        public abstract string GetAllText(string filePath);
    }
}
