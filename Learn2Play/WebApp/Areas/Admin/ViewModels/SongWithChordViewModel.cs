using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongWithChordViewModel
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int ChordId { get; set; }
        public SelectList ChordSelectList { get; set; }
    }
}