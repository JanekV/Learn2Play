using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class VideoCreateEditViewModel
    {
        public Video Video { get; set; }
        public SelectList SongSelectList { get; set; }
    }
}