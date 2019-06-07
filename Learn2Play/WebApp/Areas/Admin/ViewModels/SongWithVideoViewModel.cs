using BLL.App.DTO.DomainEntityDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongWithVideoViewModel
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public SelectList VideoSelectList { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}