using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongCreateEditViewModel
    {
        public Song Song { get; set; }
        public SelectList SongKeySelectList { get; set; }
    }
}