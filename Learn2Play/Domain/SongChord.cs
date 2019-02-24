namespace Domain
{
    public class SongChord
    {
        public int SongChordId { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }
        
    }
}