using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class UserFolder: DomainEntity
    {

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }
    }
}