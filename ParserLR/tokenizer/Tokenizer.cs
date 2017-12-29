using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tokenizer
{
    public class Tokenizer
    {
        private static string specialCharacter = @"\<>/='"""; // character "<", ">", "/", "=", "'" or "

        private static string pattern =
        // https://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet
        // \s	Matches any white space including space, tab, form-feed, etc. Equivalent to "[ \f\n\r\t\v]".
        @"(\s+)|" +                    // issue fixed: s* replaced with s+				
        @"([" + specialCharacter + "])|" +	  
        @"([^"+specialCharacter+@"\s]+)|" +		// text without specialCharacter and without whitespace
        @"([^\s]+)";

        private string input;
        private Regex regexPattern;

        private List<Token> tokens = null;

        private List<TokenType> tokenTypeValues;

        public Tokenizer(string input)
        {
            this.input = input;
            this.regexPattern = new Regex(pattern);
            this.tokenTypeValues = new List<TokenType> ();
            foreach (TokenType item in Enum.GetValues(typeof(TokenType)))
            {
                tokenTypeValues.Add(item);
            }            
        }

        private List<Token> CreateTokenList() 
        {
            List<Token> tokenList = new List<Token>();

            MatchCollection matches = regexPattern.Matches(input);	
            foreach (Match match in matches)
            {
                int i = 0;
                foreach (Group group in match.Groups)
                {
                    string matchValue = group.Value;
                    bool success = group.Success;
                    // string groupName = group.Name;
                    // ignore capture index 0(general)
                    if ( success && i > 0)
                    {
                        TokenType tokenType = tokenTypeValues[i-1];
                        tokenList.Add(new Token(tokenType , matchValue));
                    }
                    i++;
                }   
            }
            return tokenList;
        }

        public List<Token> TokenList
        {
            get
            {
                if (this.tokens == null)
                {
                    this.tokens = CreateTokenList();
                }
                return this.tokens;
            }
        }
    }
}
