using System.Collections.Generic;
using Domain;
using UserFolder = DAL.App.DTO.DomainEntityDTOs.UserFolder;
using UserInstrument = DAL.App.DTO.DomainEntityDTOs.UserInstrument;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        public ICollection<UserFolder> UserFolders { get; set; }
        public ICollection<UserInstrument> UserInstruments { get; set; }
        
    }

}