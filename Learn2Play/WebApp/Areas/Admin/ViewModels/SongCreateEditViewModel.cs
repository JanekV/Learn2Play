using Microsoft.AspNetCore.Mvc.Rendering;
using Song = BLL.App.DTO.DomainEntityDTOs.Song;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongCreateEditViewModel
    {
        public Song Song { get; set; }
        public SelectList SongKeySelectList { get; set; }
    }
}