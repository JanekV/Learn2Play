using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Note: BaseEntity
    {
        
        [MaxLength(5)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        public ICollection<TuningNote> TuningNotes { get; set; }
        public ICollection<ChordNote> ChordNotes { get; set; }
        public ICollection<SongKey> SongKeys { get; set; }
    }
}