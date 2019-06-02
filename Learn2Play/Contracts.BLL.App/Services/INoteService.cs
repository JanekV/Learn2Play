using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface INoteService : IBaseEntityService<BLLAppDTO.Note>, INoteRepository<BLLAppDTO.Note>
    {
        Task AddMultipleAsync(List<BLLAppDTO.Note> notes);

    }
}