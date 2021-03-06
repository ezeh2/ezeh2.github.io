
namespace tokenizer
{
    public class Token
    {
        public readonly TokenType TokenType;
        public readonly string Value;
        public Token(TokenType tokenType,string value)
        {
            TokenType = tokenType;
            Value = value;
        }

        public override string ToString() {
            return $"Token: {TokenType.ToString()}, {Value}";
        }
    }
}
