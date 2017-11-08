using System;
using Xunit;

namespace ExampleTest
{
    public class ExampleTest
    {
        [Fact]
        public void Test()
        {
            int one = 1;
            int two = 2;
            int result = one + two;
            Assert.Equal(3, result);
        }
    }
}
