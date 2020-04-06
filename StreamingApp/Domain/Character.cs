namespace StreamingApp.Domain
{
    public class Character
    {
        public char Letter { get; set; }
        public int Frequency { get; set; }

        public Character(char letter)
        {
            this.Letter = letter;
            this.Frequency = 1;
        }
    }
}
