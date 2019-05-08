using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class Note
    {
        public int Id { get; set; }
        
        [MaxLength(5)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        //public ICollection<TuningNote> TuningNotes { get; set; }
        //public ICollection<Domain.ChordNote> ChordNotes { get; set; }
        //public ICollection<SongKey> SongKeys { get; set; }
    }
}