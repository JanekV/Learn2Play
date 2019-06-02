using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;

namespace BLL.App.DTO
{
    public class ChordWithNotes
    {
        public int Id { get; set; } 
        public string ChordName { get; set; }
        public string ShapePicturePath { get; set; }

        public List<Note> Notes { get; set; }
    }
}