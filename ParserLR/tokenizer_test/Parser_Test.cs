using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Parser_Test
    {
        [Theory]
        // [InlineData("",0)]
        [InlineData(" ",1)]
        [InlineData(" sc ss",1)]        
        // [InlineData(" sc ss<aa>",2)] 
        public void Test1(string value,int count)
        {
            Parser parser = new Parser(value);
            Assert.Equal(count,parser.CreateParsedItems().Count);            
        }
    }
}