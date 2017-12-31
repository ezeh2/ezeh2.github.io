using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Parser_Test
    {
        [Theory]
        [InlineData(" sc ss<aa>",ParsedItemType.HtmlTagBegin,0)]
        [InlineData(" sc ss< aa >",ParsedItemType.HtmlTagBegin,0)]
        [InlineData(" sc ss<aa x=y >",ParsedItemType.HtmlTagBegin,1)]
        [InlineData(" sc ss<aa x=y rr=ss>",ParsedItemType.HtmlTagBegin,2)]
        // TODO: fix issue: 
        // [InlineData(" sc ss<aa x=y rr=ss> sdsssd",ParsedItemType.HtmlTagBegin,2)]
        [InlineData(" sc ss<aa >",ParsedItemType.HtmlTagBegin,0)]
        [InlineData(" sc ss<aa/>",ParsedItemType.HtmlTagEnd,0)]
        [InlineData(" sc ss< aa/ >",ParsedItemType.HtmlTagEnd,0)]
        [InlineData(" sc ss<aa />",ParsedItemType.HtmlTagEnd,0)]        
        public void CreateParsedItems_HtmlTagBegin_Test1(string value, ParsedItemType parsedItemType, int attributeCount)
        {
            Parser parser = new Parser(value);
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(2,parsedItems.Count);
            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);     
            Assert.Equal(parsedItemType,parsedItems[1].ParsedItemType);
            Assert.Equal("aa",parsedItems[1].Value);   
            if (parsedItemType==ParsedItemType.HtmlTagBegin)
            {
                Assert.Equal(attributeCount,parsedItems[1].Attributes.Count);                                                                                                           
            }
        }

        [Theory]
        [InlineData(" sc ss<a a>","unexpected: Token: SpecialCharacter, >")]
        [InlineData(" sc ss<a a=>","unexpected: Token: SpecialCharacter, >")]
        [InlineData(" sc ss<a /a=2>","unexpected: Token: Text, a")]
        [InlineData(" sc ss<a /x>","unexpected: Token: Text, x")]
        [InlineData(" <","expected state: 0")]
        public void CreateParsedItems_HtmlTagBeginSyntax_Error_Test2(string value, string message)
        {
            Parser parser = new Parser(value);
            // throw ApplicationException with Message "Unexpected a"
            Assert.Throws<ArgumentException>(message,()=> {parser.CreateParsedItems();});
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
        [InlineData(" sc ss<aa x=y rr=ss> sdsssd",3)]
        public void CreateParsedItems_Count_Test(string value,int count)
        {
            Parser parser = new Parser(value);
            Assert.Equal(count,parser.CreateParsedItems().Count);            
        }
    }
}