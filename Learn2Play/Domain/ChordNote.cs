namespace Domain
{
    public class ChordNote: BaseEntity
    {

        public int ChordId { get; set; }
        public Chord Chord { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}