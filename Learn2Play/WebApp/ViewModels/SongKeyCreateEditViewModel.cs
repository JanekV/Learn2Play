using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongKeyCreateEditViewModel
    {
        public SongKey SongKey { get; set; }
        public SelectList NoteSelectList { get; set; }
    }
}