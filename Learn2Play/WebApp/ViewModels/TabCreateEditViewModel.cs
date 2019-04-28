using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tab = BLL.App.DTO.DomainEntityDTOs.Tab;

namespace WebApp.ViewModels
{
    public class TabCreateEditViewModel
    {
        public Tab Tab { get; set; }
        public SelectList VideoSelectList { get; set; }
    }
}