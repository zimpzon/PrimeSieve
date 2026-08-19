namespace PrieveSieveLibTest
{
    public class PrimeSieveTest
    {
        [Fact]
        public void IsOutOfBounds()
        {
            PrimeSieveLib.PrimeSieve.IsPrime(PrimeSieveLib.PrimeSieve.MAX_PRIME + 1, out bool outOfBounds);
            Assert.True(outOfBounds);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(11)]
        [InlineData(17)]
        public void IsPrime(int n)
        {
            Assert.True(PrimeSieveLib.PrimeSieve.IsPrime(n, out bool _));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(16)]
        [InlineData(36)]
        public void IsNotPrime(int n)
        {
            Assert.False(PrimeSieveLib.PrimeSieve.IsPrime(n, out bool _));
        }
    }
}
