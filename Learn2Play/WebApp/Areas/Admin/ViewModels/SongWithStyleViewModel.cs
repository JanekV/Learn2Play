using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongWithStyleViewModel
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int StyleId { get; set; }
        public SelectList StyleSelectList { get; set; }
    }
}