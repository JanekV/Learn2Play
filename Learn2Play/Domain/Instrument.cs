using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Instrument: BaseEntity
    {

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        public string Description { get; set; }
    }
}