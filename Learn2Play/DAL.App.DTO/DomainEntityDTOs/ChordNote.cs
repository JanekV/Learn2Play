namespace DAL.App.DTO.DomainEntityDTOs
{
    public class ChordNote
    {

        public int Id { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}