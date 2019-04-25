namespace Domain
{
    public class ChordNote: DomainEntity
    {

        public int ChordId { get; set; }
        public Chord Chord { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}