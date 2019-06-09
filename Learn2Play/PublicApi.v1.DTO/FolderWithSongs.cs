using System.Collections.Generic;
using PublicApi.v1.DTO.DomainEntityDTOs;

namespace PublicApi.v1.DTO
{
    public class FolderWithSongs
    {
        public int Id { get; set; }

        public List<Song> Songs { get; set; }

        public string FolderType { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}