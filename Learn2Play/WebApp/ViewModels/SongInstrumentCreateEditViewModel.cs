using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongInstrumentCreateEditViewModel
    {
        public SongInstrument SongInstrument { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList InstrumentSelectList { get; set; }
    }
}