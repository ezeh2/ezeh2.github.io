using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Parser_Test
    {
        [Fact]
        public void CreateParsedItems_Value_Test1()
        {
            Parser parser = new Parser(" sc ss<aa>");
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(2,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(ParsedItemType.HtmlTagBegin,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);                                                       
        }

        [Fact]
        public void CreateParsedItems_Value_Test2()
        {
            Parser parser = new Parser(" sc ss< aa >");
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(2,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(ParsedItemType.HtmlTagBegin,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);                                                       
        }        

        [Fact]
        public void CreateParsedItems_Value_Test3()
        {
            Parser parser = new Parser(" sc ss<aa> x/a+2");
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(3,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(ParsedItemType.HtmlTagBegin,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);  
            Assert.Equal(ParsedItemType.Text,parsedItems[2].ParsedItemType);
            Assert.Equal(" x/a+2",parsedItems[2].Value);                                                                                                                        
        }        

        [Theory]
        [InlineData("",0)]
        [InlineData(" ",1)]
        [InlineData(" sc ss",1)]        
        [InlineData(" sc ss<aa>",2)] 
        public void CreateParsedItems_Count_Test(string value,int count)
        {
            Parser parser = new Parser(value);
            Assert.Equal(count,parser.CreateParsedItems().Count);            
        }
    }
}