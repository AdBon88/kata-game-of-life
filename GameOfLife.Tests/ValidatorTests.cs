using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GameOfLife.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        public void ShouldParseDimensionForValidInput(string input, int expectedDimension)
        {
            InputValidator.TryParseGridDimension(input, out var actualDimension);
            Assert.Equal(expectedDimension, actualDimension);
        }
        
        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("abc")]
        public void DimensionsOfLessThan1AndNonNumbersAreInvalid(string input)
        {
            Assert.False(InputValidator.TryParseGridDimension(input, out _));
        }
    }
}
