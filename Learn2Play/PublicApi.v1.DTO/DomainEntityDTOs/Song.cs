using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class Song
    {
        public int Id { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string Author { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        public string SpotifyLink { get; set; }
        
        /*[MaxLength(1000)]
        [MinLength(1)]
        public string Description { get; set; }*/

        /*public int SongKeyId { get; set; }
        public SongKey SongKey { get; set; }*/
        
    }
}