using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Video: DomainEntity
    {

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
        public int SongId { get; set; }
        public Song Song { get; set; }

        public ICollection<Tab> Tabs { get; set; }
    }
}