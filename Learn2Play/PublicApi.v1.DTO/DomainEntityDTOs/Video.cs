using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class Video
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string YouTubeUrl { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string AuthorChannelLink { get; set; }

        [MaxLength(255)]
        [MinLength(1)]
        public string LocalPath { get; set; }
        /*public int SongId { get; set; }  No need for in current functionality
        public Song Song { get; set; }*/

    }
}