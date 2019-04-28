using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;

namespace BLL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        public ICollection<UserFolder> UserFolders { get; set; }
        public ICollection<UserInstrument> UserInstruments { get; set; }
        
    }

}