using System;
using Xunit;

namespace KNet.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void EqualNumberChecker(int myInt, int mySecondInt)
        {
            Assert.Equal(myInt, mySecondInt);
        }


    }
}
