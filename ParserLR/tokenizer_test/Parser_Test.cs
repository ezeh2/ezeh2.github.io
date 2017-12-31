using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Parser_Test
    {
        [Theory]
        [InlineData(" sc ss<aa>",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss< aa >",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss<aa >",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss<aa/>",ParsedItemType.HtmlTagEnd)]
        [InlineData(" sc ss< aa/ >",ParsedItemType.HtmlTagEnd)]
        [InlineData(" sc ss<aa />",ParsedItemType.HtmlTagEnd)]        
        public void CreateParsedItems_HtmlTagBegin_Test1(string value, ParsedItemType parsedItemType)
        {
            Parser parser = new Parser(value);
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(2,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(parsedItemType,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);                                                       
        }

        [Theory]
        [InlineData(" sc ss<a a>")]
        [InlineData(" sc ss<a /x>")]
        [InlineData(" <")]
        public void CreateParsedItems_HtmlTagBeginSyntax_Error_Test2(string value)
        {
            Parser parser = new Parser(value);
            // throw ApplicationException with Message "Unexpected a"
            Assert.Throws<ArgumentException>(()=> {parser.CreateParsedItems();});
        }        

        [Theory]
        [InlineData(" sc ss<aa> x/a+2",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss< aa> x/a+2",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss< aa > x/a+2",ParsedItemType.HtmlTagBegin)]
        [InlineData(" sc ss<aa/> x/a+2",ParsedItemType.HtmlTagEnd)]
        [InlineData(" sc ss< aa/> x/a+2",ParsedItemType.HtmlTagEnd)]
        [InlineData(" sc ss< aa/ > x/a+2",ParsedItemType.HtmlTagEnd)]        
        public void CreateParsedItems_HtmlTagBegin_Test3(string value, ParsedItemType parsedItemType)
        {
            Parser parser = new Parser(value);
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(3,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(parsedItemType,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);  
            Assert.Equal(ParsedItemType.Text,parsedItems[2].ParsedItemType);
            Assert.Equal(" x/a+2",parsedItems[2].Value);                                                                                                                        
        }        

        [Theory]
        [InlineData("",0)]
        [InlineData(" ",1)]
        [InlineData(" sc ss",1)]        
        [InlineData(" sc ss<aa>",2)] 
        [InlineData(" sc ss< aa >",2)] 
        [InlineData(" sc ss<aa/>",2)] 
        [InlineData(" sc ss< aa / >",2)] 
        public void CreateParsedItems_Count_Test(string value,int count)
        {
            Parser parser = new Parser(value);
            Assert.Equal(count,parser.CreateParsedItems().Count);            
        }
    }
}