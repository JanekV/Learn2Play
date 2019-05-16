using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class SongChordService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongChord, DAL.App.DTO.DomainEntityDTOs.SongChord, IAppUnitOfWork>, ISongChordService
    {
        public SongChordService(IAppUnitOfWork uow) : base(uow, new SongChordMapper())
        {
            ServiceRepository = Uow.SongChords;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongChord>> AllAsyncWithInclude()
        {
            return (await Uow.SongChords.AllAsyncWithInclude()).Select(SongChordMapper.MapFromDAL).ToList();
        }
    }
}