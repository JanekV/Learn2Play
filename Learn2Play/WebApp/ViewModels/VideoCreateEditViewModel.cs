using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Video = BLL.App.DTO.DomainEntityDTOs.Video;

namespace WebApp.ViewModels
{
    public class VideoCreateEditViewModel
    {
        public Video Video { get; set; }
        public SelectList SongSelectList { get; set; }
    }
}