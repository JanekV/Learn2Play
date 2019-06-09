using System.Collections.Generic;
using PublicApi.v1.DTO.DomainEntityDTOs;

namespace PublicApi.v1.DTO
{
    public class AddSongToFolder
    {
        public string FolderName { get; set; }
        public int FolderId { get; set; }
        public int SongId { get; set; }

        public List<Song> Songs { get; set; }
    }
}