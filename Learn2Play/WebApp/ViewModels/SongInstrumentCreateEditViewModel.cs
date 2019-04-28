using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using SongInstrument = BLL.App.DTO.DomainEntityDTOs.SongInstrument;

namespace WebApp.ViewModels
{
    public class SongInstrumentCreateEditViewModel
    {
        public SongInstrument SongInstrument { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList InstrumentSelectList { get; set; }
    }
}