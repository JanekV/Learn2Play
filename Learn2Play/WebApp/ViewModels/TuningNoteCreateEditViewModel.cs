using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TuningNoteCreateEditViewModel
    {
        public TuningNote TuningNote { get; set; }
        public SelectList InstrumentSelectList { get; set; }
        public SelectList NoteSelectList { get; set; }

    }
}