
namespace BLL.App.DTO.DomainEntityDTOs
{
    public class SongStyle
    {
        public int Id { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}