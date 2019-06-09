using System.Collections.Generic;
using PublicApi.v1.DTO.DomainEntityDTOs;

namespace PublicApi.v1.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        public List<UserFolder> UserFolders { get; set; }
        //public ICollection<UserInstrument> UserInstruments { get; set; }
        
    }

}