
namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class SongChord
    {
        public int Id { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }
        
    }
}