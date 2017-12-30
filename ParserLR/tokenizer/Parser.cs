using System;
using System.Collections.Generic;


namespace tokenizer
{
    public class Parser
    {
        private Tokenizer tokenizer;
        private int state = 0;
        private List<ParsedItem> parsedItems = new List<ParsedItem>();

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
                    parsedItems.Add(new ParsedItem(ParsedItemType.Text,"text") );   
                    break;      
                case 1:
                    parsedItems.Add(new ParsedItem(ParsedItemType.HtmlTagBegin,"htmltagname",null) );                  
                    break;                                        
            }
            state=newState;
        }

        private void Process0(Token token)
        {
            if ((token.TokenType==TokenType.Text) || (token.TokenType==TokenType.WhiteSpace))
            {
                
            }               
            else if ( (token.TokenType==TokenType.SpecialCharacter) && (token.Value=="<") )
            {
                ChangeState(1);
            }         
            else
            {
                throw new ApplicationException($"unexpected: {token.ToString()}");
            }
        }

        private void Process1(Token token)
        {
            if ((token.TokenType==TokenType.Text) || (token.TokenType==TokenType.WhiteSpace))
            {

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

