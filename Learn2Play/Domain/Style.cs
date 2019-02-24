using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Style
    {
        public int StyleId { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Description { get; set; }
    }
}