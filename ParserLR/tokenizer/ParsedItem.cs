using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tokenizer
{
    public class ParsedItem
    {
        public ParsedItem(ParsedItemType parsedItemType, string value, Dictionary<string,string> attributes)
        {
            if (parsedItemType!=ParsedItemType.HtmlTagBegin)
            {
                throw new ArgumentException("only allowed: ParsedItemType.HtmlTagBegin");
            }

            this.ParsedItemType = parsedItemType;
            this.Value = value;
            this.Attributes = attributes;
        }

        public ParsedItem(ParsedItemType parsedItemType, string value)
        {
            if (parsedItemType==ParsedItemType.HtmlTagBegin)
            {
                throw new ArgumentException("not allowed: ParsedItemType.HtmlTagBegin");
            }

            this.ParsedItemType = parsedItemType;
            this.Value = value;
        }

       public ParsedItemType ParsedItemType {get; private set;}
       public string Value {get; private set;}

       public Dictionary<string,string> Attributes {get; private set;}
    }
}

