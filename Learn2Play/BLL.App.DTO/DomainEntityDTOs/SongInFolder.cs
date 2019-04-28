namespace BLL.App.DTO.DomainEntityDTOs
{
    public class SongInFolder
    {
        public int Id { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}