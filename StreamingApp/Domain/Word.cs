namespace StreamingApp.Domain
{
    public class Word
    {
        public string Text { get; set; }
        public int Length { get; set; }
        public int Frequency { get; set; }

        public Word(string text, int length)
        {
            Text = text;
            Length = length;
            Frequency = 1;
        }
    }
}
