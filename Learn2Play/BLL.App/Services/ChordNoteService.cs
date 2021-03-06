using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ee.itcollege.javalg.BLL.Base.Services;
using ChordNote = BLL.App.DTO.DomainEntityDTOs.ChordNote;

namespace BLL.App.Services
{
    public class ChordNoteService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.ChordNote, DAL.App.DTO.DomainEntityDTOs.ChordNote, IAppUnitOfWork>, IChordNoteService
    {
        public ChordNoteService(IAppUnitOfWork uow) : base(uow, new ChordNoteMapper())
        {
            ServiceRepository =
                Uow.ChordNotes;  //Uow.BaseRepository<DAL.App.DTO.DomainEntityDTOs.ChordNote, Domain.ChordNote>();
        }
        public async Task<List<BLL.App.DTO.DomainEntityDTOs.ChordNote>> AllAsyncWithInclude()
        {
            return (await Uow.ChordNotes.AllAsyncWithInclude()).Select(ChordNoteMapper.MapFromDAL).ToList();
        }

        public void RemoveByNote(int noteId)
        {
            Uow.ChordNotes.RemoveByNote(noteId);
        }
    }
}