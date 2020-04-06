namespace StreamingApp.Extensions
{
    public static partial class CharExtensions
    {
        public static bool IsSpaceOrFullStop(this char ch)
        {
            return ch == ' ' || ch == '.';
        }
    }
}