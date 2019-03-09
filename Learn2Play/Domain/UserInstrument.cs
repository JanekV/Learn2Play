using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class UserInstrument: BaseEntity
    {

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }
    }
}