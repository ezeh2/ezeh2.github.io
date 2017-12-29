using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Tokenizer_Test
    {
        [Fact]
        public void TokenList_Value_Test()
        {
            Tokenizer tokenizer = new Tokenizer(" a /y");
            Assert.Equal(5,tokenizer.TokenList.Count);
            Assert.Equal(TokenType.WhiteSpace,tokenizer.TokenList[0].TokenType);
            Assert.Equal(" ",tokenizer.TokenList[0].Value);
            Assert.Equal(TokenType.Text,tokenizer.TokenList[1].TokenType);
            Assert.Equal("a",tokenizer.TokenList[1].Value);
            Assert.Equal(TokenType.WhiteSpace,tokenizer.TokenList[2].TokenType);
            Assert.Equal(" ",tokenizer.TokenList[2].Value);            
            Assert.Equal(TokenType.WhiteSpace,tokenizer.TokenList[3].TokenType);
            Assert.Equal(" ",tokenizer.TokenList[3].Value);            
            Assert.Equal(TokenType.WhiteSpace,tokenizer.TokenList[4].TokenType);
            Assert.Equal(" ",tokenizer.TokenList[4].Value);                        
        }

        [Theory]
        [InlineData("",0)]
        [InlineData(" ",1)]
        [InlineData("  ",1)]
        [InlineData(" a",2)]        
        [InlineData(" abc",2)]
        [InlineData(" <",2)]
        [InlineData(" < ",3)]        
        [InlineData(" <a",3)]        
        [InlineData(" <ab",3)]                
        [InlineData(" <ab>",4)]                
        [InlineData(" <ab> ",5)] 
        [InlineData(" <ab > ",6)]         
        [InlineData(" <ab /> ",7)]                 
        [InlineData(" <ab h='sgg'> ",11)]                 
        [InlineData(" a ",3)]                       
        [InlineData(" abc ",3)]
        public void TokenListList_Count_Test(string value, int count)
        {
            Tokenizer tokenizer = new Tokenizer(value);
            Assert.Equal(count,tokenizer.TokenList.Count);
        }
    }
}
