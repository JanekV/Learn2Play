using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;

namespace BLL.App.DTO
{
    public class FolderWithSong
    {
        public int Id { get; set; }

        public List<Song> Songs { get; set; }

        public string FolderType { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}