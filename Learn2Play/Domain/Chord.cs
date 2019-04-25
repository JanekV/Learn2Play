using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Chord: DomainEntity
    {
        
        [MaxLength(10)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string ShapePicturePath { get; set; }


        public ICollection<SongChord> SongChords { get; set; }
        public ICollection<ChordNote> ChordNotes { get; set; }
    }
}