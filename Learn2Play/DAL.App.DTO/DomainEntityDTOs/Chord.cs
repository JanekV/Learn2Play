using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO.DomainEntityDTOs
{
    public class Chord
    {
        public int Id { get; set; }
        
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