using BLL.App.DTO.DomainEntityDTOs;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ChordWithNoteViewModel
    {
        public int ChordId { get; set; }
        public string ChordName { get; set; }
        public Note Note { get; set; }
    }
}