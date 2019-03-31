using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Folder: BaseEntity
    {

        public FolderType FolderType { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(1000)]
        [MinLength(1)]
        public string Comment { get; set; }
             
    }

    public enum FolderType
    {
        CurrentlyLearning,
        Favorites,
        Other
    }
}