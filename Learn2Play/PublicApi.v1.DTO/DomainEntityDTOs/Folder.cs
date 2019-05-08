using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace PublicApi.v1.DTO.DomainEntityDTOs
{
    public class Folder
    {
        public int Id { get; set; }

        public FolderType FolderType { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }

        //public ICollection<UserFolder> UserFolders { get; set; }
        //public ICollection<SongInFolder> SongInFolders { get; set; }
    }

}