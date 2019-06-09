
using System.Collections.Generic;
using PublicApi.v1.DTO.DomainEntityDTOs;

namespace PublicApi.v1.DTO
{
    public class FolderWithSong
    {
        public int FolderId { get; set; }

        public Song Song { get; set; }
        public List<Song> Songs { get; set; }
    }
}