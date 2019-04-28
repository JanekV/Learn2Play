using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using SongChord = BLL.App.DTO.DomainEntityDTOs.SongChord;

namespace WebApp.ViewModels
{
    public class SongChordCreateEditViewModel
    {
        public SongChord SongChord { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList ChordSelectList { get; set; }
    }
}