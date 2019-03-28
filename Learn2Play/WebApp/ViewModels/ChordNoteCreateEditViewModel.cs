using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ChordNoteCreateEditViewModel
    {
        public ChordNote ChordNote { get; set; }
        public SelectList ChordSelectList { get; set; }
        public SelectList NoteSelectList { get; set; }
    }
}