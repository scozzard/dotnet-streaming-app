using System.Linq;
using Xunit;
using StreamingApp.Services;

namespace StreamingApp.Tests.Services
{
    public class StreamingServiceTests
    {
        [Theory]
        [InlineData('A', "word")]
        [InlineData('a', "word")]
        [InlineData('D', "word")]
        [InlineData('g', "word")]
        [InlineData('Z', "word")]
        public void AddCharacterToWord_Will_Add_Character_To_Word_If_It_Is_A_Letter(char ch, string word)
        {
            var service = new StreamingService();

            var updatedWord = service.AddCharacterToWord(ch, word);

            Assert.Equal(updatedWord, word + ch.ToString());
        }

        [Theory]
        [InlineData(' ', "word")]
        [InlineData('.', "word")]
        public void AddCharacterToWord_Will_Not_Add_Character_To_Word_If_It_Is_A_Space_Or_Full_Stop(char ch, string word)
        {
            var service = new StreamingService();

            var updatedWord = service.AddCharacterToWord(ch, word);

            Assert.Equal(updatedWord, word);
        }

        [Theory]
        [InlineData(' ', "word")]
        [InlineData('.', "word")]
        public void IsEndOfWord_Will_Return_True_If_Character_Is_A_Space_Or_A_Full_Stop_And_The_Word_Is_Not_Empty(char ch, string word)
        {
            var service = new StreamingService();

            var result = service.IsEndOfWord(ch, word);

            Assert.True(result);
        }

        [Theory]
        [InlineData('A', "word")]
        [InlineData(' ', "")]
        [InlineData('.', "")]
        public void IsEndOfWord_Will_Return_False_If_Character_A_Letter_Or_The_Word_Is_Empty(char ch, string word)
        {
            var service = new StreamingService();

            var result = service.IsEndOfWord(ch, word);

            Assert.False(result);
        }

        [Fact]
        public void AddWordToSummary_Will_Add_New_Word_To_List_Of_Words_In_Summary_With_Frequency_1_If_It_Doesnt_Exist()
        {
            var service = new StreamingService();
            const string text = "word";

            service.AddWordToSummary(text);

            var word = service.summary.Words.FirstOrDefault(w => w.Text == text);
            Assert.NotNull(word);
            Assert.Equal(text, word.Text);
            Assert.Equal(1, word.Frequency);
        }

        [Fact]
        public void AddWordToSummary_Will_Increment_Frequency_Of_Word_In_List_Of_Words_In_Summary_If_It_Does_Exist()
        {
            var service = new StreamingService();
            const string text = "word";
            service.summary.Words.Add(new Domain.Word(text, 4));
            var totalWords = service.summary.Words.Count();

            service.AddWordToSummary(text);

            var word = service.summary.Words.FirstOrDefault(w => w.Text == text);
            Assert.NotNull(word);
            Assert.Equal(text, word.Text);
            Assert.Equal(2, word.Frequency);
            Assert.Equal(totalWords, service.summary.Words.Count());
        }
    }
}
