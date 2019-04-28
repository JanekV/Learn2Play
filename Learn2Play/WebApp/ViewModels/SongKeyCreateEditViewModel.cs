using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using SongKey = BLL.App.DTO.DomainEntityDTOs.SongKey;

namespace WebApp.ViewModels
{
    public class SongKeyCreateEditViewModel
    {
        public SongKey SongKey { get; set; }
        public SelectList NoteSelectList { get; set; }
    }
}