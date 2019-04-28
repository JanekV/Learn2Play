using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserInstrument = BLL.App.DTO.DomainEntityDTOs.UserInstrument;

namespace WebApp.ViewModels
{
    public class UserInstrumentCreateEditViewModel
    {
        public UserInstrument UserInstrument { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList InstrumentSelectList { get; set; }
    }
}