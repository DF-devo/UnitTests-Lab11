using Xunit;
using ChessExample;
namespace CheckerChessPositionTest
{
    public class TryParseValidInput
    {
        [Theory]
        [InlineData("A1", "1", "1")]
        [InlineData("B5", "2", "5")]
        [InlineData("D7", "4", "7")]
        public void TryParseTest(string s, string expectedX, string expectedY)
        {
            var isComplete = CheckerBoardPosition.TryParse(s, null, out CheckerBoardPosition? result);
            Assert.True(isComplete);
            Assert.NotNull(result);
            Assert.Equal(expectedY, result.Y.ToString());
            Assert.Equal(expectedX, result.X.ToString());
        } 
    }
    public class TryParseInValidInput
    {
        [Theory]
        [InlineData("8D")]
        [InlineData("11")]
        [InlineData("AA")]
        [InlineData("A0")]
        [InlineData("L3")]
        [InlineData("A10")]
        [InlineData(" B5")]
        [InlineData("C7 ")]
        [InlineData(null)]
        public void TryParseTest(string? s)
        {
            var isComplete = CheckerBoardPosition.TryParse(s, null, out CheckerBoardPosition? result);
            Assert.False(isComplete);
            Assert.Null(result);
        }
    }

    

    public class CoordinateValidInput
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 6)]
        [InlineData(3, 8)]
        [InlineData(7, 4)]
        public void CoordinateTestValidInput(byte x, byte y)
        {
            var result = new CheckerBoardPosition(x, y);
            char expectedLetter = (char)('@' + x);
            string expectedResult = expectedLetter.ToString() + y.ToString();
            Assert.Equal(y, result.Y);
            Assert.Equal(x, result.X);
            Assert.Equal(expectedLetter, result.XLetter);
            Assert.Equal(expectedResult, result.ToString());
        }
    }
    public class CoordinateInValidInput
    {
        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 9)]
        [InlineData(9, 10)]
        public void CoordinateTestInvalidInput(byte x, byte y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(x,y));
        }
    }
 
    public class ParseValidInput
    {
        [Theory]
        [InlineData("B8", "2", "8")]
        [InlineData("C4", "3", "4")]
        [InlineData("A1", "1", "1")]
        public void ParseTest(string s, string expectedX, string expectedY )
        {
            var result = CheckerBoardPosition.Parse(s, null);
            Assert.NotNull(result);
            Assert.Equal(expectedY, result.Y.ToString());
            Assert.Equal(expectedX, result.X.ToString());
            Assert.Equal(s, result.ToString());

        }
    }

    public class ParseInvalidInput
    {
        [Theory]
        [InlineData("8D")]
        [InlineData("11")]
        [InlineData("AA")]
        [InlineData("A0")]
        [InlineData("L3")]
        [InlineData("A10")]
        [InlineData(null)]
        public void ParseTest(string? s)
        {
            Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(s, null));
        }
    }

}

