using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Note
    {
        public int NoteId { get; set; }
        
        [MaxLength(5)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}