using StreamingApp.Extensions;
using Xunit;

namespace StreamingApp.Tests.Extensions
{
    public class CharExtensionTests
    {
        [Theory]
        [InlineData(' ')]
        [InlineData('.')]
        public void IsSpaceOrFullStop_Returns_True_When_Char_Is_Space_Or_Full_Stop(char ch)
        {
            Assert.True(ch.IsSpaceOrFullStop());
        }

        [Theory]
        [InlineData('a')]
        [InlineData('D')]
        [InlineData('n')]
        [InlineData('T')]
        [InlineData('z')]
        public void IsSpaceOrFullStop_Returns_False_When_Char_Is_Not_A_Space_Or_Full_Stop(char ch)
        {
            Assert.False(ch.IsSpaceOrFullStop());
        }
    }
}
