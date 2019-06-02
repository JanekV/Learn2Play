using System.Collections.Generic;
using DAL.App.DTO.DomainEntityDTOs;

namespace DAL.App.DTO
{
    public class ChordWithNotes
    {
        public int Id { get; set; }
        public int ChordId { get; set; }
        public string ChordName { get; set; }
        public string ShapePicturePath { get; set; }

        public List<Note> Notes { get; set; }
    }
}