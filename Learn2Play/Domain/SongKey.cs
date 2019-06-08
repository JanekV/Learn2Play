using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SongKey: DomainEntity
    {

        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}