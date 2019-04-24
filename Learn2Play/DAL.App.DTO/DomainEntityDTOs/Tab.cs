using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace DAL.App.DTO.DomainEntityDTOs
{
    public class Tab
    {
        public int Id { get; set; }

        [Required]
        public SongPart SongPart { get; set; }
        
        [MaxLength(30)]
        [MinLength(1)]
        [Required]
        public string StrummingPattern { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        public string PicturePath { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        public string Link { get; set; }
        
        [MaxLength(100)]
        [MinLength(1)]
        public string Author { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }
        
    }

}