using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Instrument: DomainEntity
    {

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        public string Description { get; set; }

        public ICollection<UserInstrument> UserInstruments { get; set; }
        public ICollection<TuningNote> TuningNotes { get; set; }
        public ICollection<SongInstrument> SongInstruments { get; set; }
    }
}