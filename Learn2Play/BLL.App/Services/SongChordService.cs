using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongChordService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongChord, DAL.App.DTO.DomainEntityDTOs.SongChord, IAppUnitOfWork>, ISongChordService
    {
        public SongChordService(IAppUnitOfWork uow) : base(uow, new SongChordMapper())
        {
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongChord>> AllAsyncWithInclude()
        {
            return (await Uow.SongChords.AllAsyncWithInclude()).Select(SongChordMapper.MapFromDAL).ToList();
        }
    }
}