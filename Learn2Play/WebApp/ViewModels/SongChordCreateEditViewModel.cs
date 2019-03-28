using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongChordCreateEditViewModel
    {
        public SongChord SongChord { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList ChordSelectList { get; set; }
    }
}