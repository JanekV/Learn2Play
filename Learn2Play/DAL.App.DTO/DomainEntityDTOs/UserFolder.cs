using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO.DomainEntityDTOs
{
    public class UserFolder
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }
    }
}