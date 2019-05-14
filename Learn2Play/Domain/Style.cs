using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Style: DomainEntity
    {

        public int NameId { get; set; }
        public MultiLangString Name { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Description { get; set; }

        public ICollection<SongStyle> SongStyles { get; set; }
    }
}