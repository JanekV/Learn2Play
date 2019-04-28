using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class VideoMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Video))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Video) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Video))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Video) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Video MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Video video)
        {
            var res = video == null ? null : new BLL.App.DTO.DomainEntityDTOs.Video
            {
                Id = video.Id,
                YouTubeUrl = video.YouTubeUrl,
                AuthorChannelLink = video.AuthorChannelLink,
                LocalPath = video.LocalPath,
                SongId = video.SongId,
                Song = SongMapper.MapFromDAL(video.Song)              
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Video MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Video video)
        {
            var res = video == null ? null : new DAL.App.DTO.DomainEntityDTOs.Video
            {
                Id = video.Id,
                YouTubeUrl = video.YouTubeUrl,
                AuthorChannelLink = video.AuthorChannelLink,
                LocalPath = video.LocalPath,
                SongId = video.SongId,
                Song = SongMapper.MapFromBLL(video.Song) 
            };

            return res;
        }

    }
}