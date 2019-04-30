using Microsoft.AspNetCore.Mvc.Rendering;
using SongInFolder = BLL.App.DTO.DomainEntityDTOs.SongInFolder;

namespace WebApp.ViewModels
{
    public class SongInFolderCreateEditViewModel
    {
        public SongInFolder SongInFolder { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList FolderSelectList { get; set; }

        
    }
}