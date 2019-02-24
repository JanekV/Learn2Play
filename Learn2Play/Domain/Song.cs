using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain
{
    public class Song
    {
        public int SongId { get; set; }

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
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Description { get; set; }

        public List<Video> Videos { get; set; }

        public int SongKeyId { get; set; }
        public SongKey Key { get; set; }
    }
}