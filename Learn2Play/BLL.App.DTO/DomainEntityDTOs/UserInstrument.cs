using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO.DomainEntityDTOs
{
    public class UserInstrument
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }
    }
}