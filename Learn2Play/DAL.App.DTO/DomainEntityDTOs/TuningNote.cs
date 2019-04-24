using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO.DomainEntityDTOs
{
    public class TuningNote
    {
        public int Id { get; set; }

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