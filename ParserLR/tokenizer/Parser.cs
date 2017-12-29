
namespace tokenizer
{
    public class Parser
    {
        private Tokenizer tokenizer;

        public Parser(string input)
        : this(new Tokenizer(input))
        {

        }

        public Parser(Tokenizer tokenizer)
        {
            this.tokenizer = tokenizer;
        }
        
    }
}

