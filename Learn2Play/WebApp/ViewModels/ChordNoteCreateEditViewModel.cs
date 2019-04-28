using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChordNote = BLL.App.DTO.DomainEntityDTOs.ChordNote;

namespace WebApp.ViewModels
{
    public class ChordNoteCreateEditViewModel
    {
        public ChordNote ChordNote { get; set; }
        public SelectList ChordSelectList { get; set; }
        public SelectList NoteSelectList { get; set; }
    }
}