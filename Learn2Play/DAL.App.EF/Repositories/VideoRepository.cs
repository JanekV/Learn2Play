using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class VideoRepository: BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}