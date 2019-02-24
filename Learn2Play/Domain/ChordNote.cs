namespace Domain
{
    public class ChordNote
    {
        public int ChordNoteId { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}