using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SongInFolderCreateEditViewModel
    {
        public SongInFolder SongInFolder { get; set; }
        public SelectList SongSelectList { get; set; }
        public SelectList FolderSelectList { get; set; }

        
    }
}