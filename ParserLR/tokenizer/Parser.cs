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
                }
            }

            ChangeState(-1);

            return parsedItems;
        }

        private void ChangeState(int newState)
        {
            switch(state)
            {
                case 0:
                    if (valueSb.Length>0)
                    {
                        parsedItems.Add(new ParsedItem(ParsedItemType.Text,valueSb.ToString()) );   
                    }
                    valueSb.Clear();
                    break;      
                case 1:
                    parsedItems.Add(new ParsedItem(ParsedItemType.HtmlTagBegin,valueSb.ToString(),null) );     
                    valueSb.Clear();                                 
                    break;                                        
            }
            state=newState;
        }

        private void Process0(Token token)
        {
            if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value=="<") )
            {
                ChangeState(1);
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
            }    
            else if (token.TokenType==TokenType.WhiteSpace)
            {
                // swallow whitespace
            }                                      
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value=="/") )
            {
            }                     
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value==">") )
            {                
                ChangeState(0);
            }         
            else
            {
                throw new ApplicationException($"unexpected: {token.ToString()}");
            }
        }        
        
    }
}

