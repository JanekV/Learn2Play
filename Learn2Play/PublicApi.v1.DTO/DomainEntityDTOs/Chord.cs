using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class Chord
    {
        public int Id { get; set; }
        
        [MaxLength(10)]
        [MinLength(1)]
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Domain.Chord))]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        [Display(Name = "ShapePicturePath", ResourceType = typeof(Resources.Domain.Chord))]
        public string ShapePicturePath { get; set; }
    }
}