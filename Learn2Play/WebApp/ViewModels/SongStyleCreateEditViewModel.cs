using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongStyleCreateEditViewModel
    {
        public SongStyle SongStyle { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList StyleSelectList { get; set; }

    }
}