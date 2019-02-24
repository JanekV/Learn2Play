using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Chord
    {
        public int ChordId { get; set; }
        
        [MaxLength(10)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string ShapePicturePath { get; set; }
        
    }
}