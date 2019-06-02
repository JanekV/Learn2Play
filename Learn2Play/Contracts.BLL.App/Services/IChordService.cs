using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface IChordService : IBaseEntityService<BLLAppDTO.Chord>, IChordRepository<BLLAppDTO.Chord>
    {
        Task<List<ChordWithNotes>> GetAllChordsWithNotesAsync();
        Task<ChordWithNotes> GetChordWithNotesAsync(int chordId);


        Task<BLLAppDTO.Chord> AddChordWithNotes(
            BLLAppDTO.Chord chord, List<BLLAppDTO.Note> notes);

        Task<BLLAppDTO.Note> AddNoteToChord(BLLAppDTO.Chord chord, BLLAppDTO.Note note);
    }
}