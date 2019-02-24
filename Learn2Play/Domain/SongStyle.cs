namespace Domain
{
    public class SongStyle
    {
        public int SongStyleId { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}