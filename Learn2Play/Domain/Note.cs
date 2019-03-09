using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Note: BaseEntity
    {
        
        [MaxLength(5)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}