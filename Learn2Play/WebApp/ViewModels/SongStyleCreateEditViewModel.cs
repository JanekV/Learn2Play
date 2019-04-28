using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using SongStyle = BLL.App.DTO.DomainEntityDTOs.SongStyle;

namespace WebApp.ViewModels
{
    public class SongStyleCreateEditViewModel
    {
        public SongStyle SongStyle { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList StyleSelectList { get; set; }

    }
}