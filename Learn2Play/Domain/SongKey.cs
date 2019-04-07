using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SongKey: BaseEntity
    {

        [MaxLength(1000)]
        [MinLength(1)]
        [Required]
        public string Description { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}