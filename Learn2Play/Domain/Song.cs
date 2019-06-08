using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain
{
    public class Song: DomainEntity
    {

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
        
        [MaxLength(10240)]
        [MinLength(1)]
        public string Description { get; set; }

        public int SongKeyId { get; set; }
        public SongKey SongKey { get; set; }

        public ICollection<SongInFolder> SongInFolders { get; set; }
        public ICollection<SongInstrument> SongInstruments { get; set; }
        public ICollection<SongStyle> SongStyles { get; set; }
        public ICollection<SongChord> SongChords { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}