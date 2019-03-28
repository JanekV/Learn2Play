using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TabCreateEditViewModel
    {
        public Tab Tab { get; set; }
        public SelectList VideoSelectList { get; set; }
    }
}