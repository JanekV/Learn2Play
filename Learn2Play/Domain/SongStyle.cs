namespace Domain
{
    public class SongStyle: DomainEntity
    {

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}