using System.Collections.Generic;
using DAL.App.DTO.DomainEntityDTOs;

namespace DAL.App.DTO
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