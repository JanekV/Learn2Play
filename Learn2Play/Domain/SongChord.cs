namespace Domain
{
    public class SongChord: DomainEntity
    {

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }
        
    }
}