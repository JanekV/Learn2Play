using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ChordCreateEditViewModel
    {
        public Chord Chord { get; set; }

        public Note Note { get; set; }
        public List<Note> Notes { get; set; }
    }
}