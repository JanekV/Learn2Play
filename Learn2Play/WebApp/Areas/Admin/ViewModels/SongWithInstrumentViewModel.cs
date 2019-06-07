using BLL.App.DTO.DomainEntityDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongWithInstrumentViewModel
    {
        public int SongId { get; set; }
        public int InstrumentId { get; set; }
        public string SongName { get; set; }
        public SelectList InstrumentSelectList { get; set; }
    }
}