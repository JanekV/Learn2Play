using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class TuningNote: BaseEntity
    {

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}