using System;
using Xunit;
using tokenizer;

namespace tokenizer_test
{
    public class Parser_Test
    {
        [Fact]
        public void Test1()
        {
            Parser parser = new Parser(" sc ss<aa x=y rr=ss> sdsssd");
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(3,parsedItems.Count);

            Assert.Equal(ParsedItemType.Text,parsedItems[0].ParsedItemType);
            Assert.Equal(" sc ss",parsedItems[0].Value);

            Assert.Equal(ParsedItemType.HtmlTagBegin,parsedItems[1].ParsedItemType);            
            Assert.Equal("aa",parsedItems[1].Value);
            Assert.Equal(2,parsedItems[1].Attributes.Count);
            Assert.Equal("y",parsedItems[1].Attributes["x"]);
            Assert.Equal("ss",parsedItems[1].Attributes["rr"]);

            Assert.Equal(ParsedItemType.Text,parsedItems[2].ParsedItemType);
            Assert.Equal(" sdsssd",parsedItems[2].Value);
        }

        [Theory]
        [InlineData(" sc ss<aa>",ParsedItemType.HtmlTagBegin,2,0)]
        [InlineData(" sc ss< aa >",ParsedItemType.HtmlTagBegin,2,0)]
        [InlineData(" sc ss<aa x=y >",ParsedItemType.HtmlTagBegin,2,1)]
        [InlineData(" sc ss<aa x=y rr=ss>",ParsedItemType.HtmlTagBegin,2,2)]
        [InlineData(" sc ss<aa x=y rr=ss> sdsssd",ParsedItemType.HtmlTagBegin,3,2)]
        [InlineData(" sc ss<aa >",ParsedItemType.HtmlTagBegin,2,0)]
        [InlineData(" sc ss<aa/>",ParsedItemType.HtmlTagEnd,2,0)]
        [InlineData(" sc ss< aa/ >",ParsedItemType.HtmlTagEnd,2,0)]
        [InlineData(" sc ss<aa />",ParsedItemType.HtmlTagEnd,2,0)]        
        public void CreateParsedItems_HtmlTagBegin_Test1(string value, ParsedItemType parsedItemType, int parsedItemCount, int attributeCount)
        {
            Parser parser = new Parser(value);
            var parsedItems = parser.CreateParsedItems();
            Assert.Equal(parsedItemCount,parsedItems.Count);
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