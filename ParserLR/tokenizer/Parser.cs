using System;
using System.Text;
using System.Collections.Generic;


namespace tokenizer
{
    public class Parser
    {
        private Tokenizer tokenizer;
        private int state = 0;
        private List<ParsedItem> parsedItems = new List<ParsedItem>();
        private StringBuilder valueSb = new StringBuilder();

        public Parser(string input)
        : this(new Tokenizer(input))
        {

        }

        public Parser(Tokenizer tokenizer)
        {
            this.tokenizer = tokenizer;
        }

        public List<ParsedItem> CreateParsedItems()
        {
            parsedItems.Clear();

            state = 0;

            foreach(Token token in tokenizer.TokenList)
            {
                switch(state)
                {
                    case 0:
                        Process0(token);
                        break;
                    case 1:
                        Process1(token);
                        break;      
                    case 2:
                        Process2(token);
                        break;                              
                    case 11:
                        Process11(token);
                        break;                                                                  
                }
            }

            if (state!=0)
            {
                throw new ArgumentException("","expected state: 0");
            }
            AddTextParsedItem();

            return parsedItems;
        }

        private void AddTextParsedItem()
        {
            if (valueSb.Length>0)
            {
                parsedItems.Add(new ParsedItem(ParsedItemType.Text,valueSb.ToString()) );   
            }
            valueSb.Clear();
        }

        private void AddHtmlTagBeginParsedItem()
        {
            parsedItems.Add(new ParsedItem(ParsedItemType.HtmlTagBegin,valueSb.ToString(),null) );     
            valueSb.Clear();                                             
        }

        private void AddHtmlTagEndParsedItem()
        {
            parsedItems.Add(new ParsedItem(ParsedItemType.HtmlTagEnd,valueSb.ToString()) );     
            valueSb.Clear();                                             
        }
        
        private void Process0(Token token)
        {
            if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value=="<") )
            {
                AddTextParsedItem();
                this.state = 1;
            }                     
            else
            {
                valueSb.Append(token.Value);
            }               
        }

        private void Process1(Token token)
        {
            if (token.TokenType==TokenType.Text)
            {
                valueSb.Append(token.Value);
                state=2;
            }    
            else if (token.TokenType==TokenType.WhiteSpace)
            {
                // swallow whitespace
            }                                      
            else
            {
                throw new ArgumentException("",$"unexpected: {token.ToString()}");
            }
        }       

        private void Process2(Token token)
        {
            if (token.TokenType==TokenType.WhiteSpace)
            {
                // swallow whitespace
            }                                      
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value=="/") )
            {
                state=11;
            }                     
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value==">") )
            {                
                AddHtmlTagBeginParsedItem();                
                state=0;
            }         
            else
            {
                throw new ArgumentException("",$"unexpected: {token.ToString()}");
            }
        }          

        private void Process11(Token token)
        {
            if (token.TokenType==TokenType.WhiteSpace)
            {
                // swallow whitespace
            }                                      
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value==">") )
            {                
                AddHtmlTagEndParsedItem();                
                state=0;
            }         
            else
            {
                throw new ArgumentException("",$"unexpected: {token.ToString()}");
            }
        }             
        
    }
}

