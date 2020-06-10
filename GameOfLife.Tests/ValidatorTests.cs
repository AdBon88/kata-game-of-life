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
        public void DimensionsOfLessThan1_NonNumbersAreInvalid(string input)
        {
            Assert.False(InputValidator.TryParseGridDimension(input, out _));
        }
        
        [Theory]
        [InlineData("1,1", new[]{1,1})]
        [InlineData("2,3", new []{2,3})]
        [InlineData("3,3", new []{3,3})]
        public void ShouldParseValidCoords(string input, int[] expectedCoords)
        {
            var grid = new GameGrid(3,3);
            Assert.True(InputValidator.TryParseCoords(input, grid, out var actualCoords));
            Assert.Equal(expectedCoords, actualCoords);
        }
        
        [Theory]
        [InlineData("3,4")]
        [InlineData("4,3")]
        [InlineData("2,2,1")]
        [InlineData("a,3")]
        [InlineData("-1,-1")]
        [InlineData("0,0")]
        [InlineData("2")]
        public void CoordsLessThan1_OutOfBounds_NonNumbers_CoordCountNot2_AreInvalid(string input)
        {
            var grid = new GameGrid(3,3);
           
            Assert.False( InputValidator.TryParseCoords(input, grid, out _) );
        }
    }
}
