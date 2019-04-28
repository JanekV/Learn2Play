using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuningNote = BLL.App.DTO.DomainEntityDTOs.TuningNote;

namespace WebApp.ViewModels
{
    public class TuningNoteCreateEditViewModel
    {
        public TuningNote TuningNote { get; set; }
        public SelectList InstrumentSelectList { get; set; }
        public SelectList NoteSelectList { get; set; }

    }
}