using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SongKey
    {
        public int SongKeyId { get; set; }

        [MaxLength(1000)]
        [MinLength(1)]
        [Required]
        public string Description { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}