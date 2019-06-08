using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Instrument: DomainEntity
    {

        public int NameId { get; set; }
        public MultiLangString Name { get; set; }

        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }

        public ICollection<UserInstrument> UserInstruments { get; set; }
        public ICollection<TuningNote> TuningNotes { get; set; }
        public ICollection<SongInstrument> SongInstruments { get; set; }
    }
}