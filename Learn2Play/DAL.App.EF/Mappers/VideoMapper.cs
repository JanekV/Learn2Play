using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class VideoMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Video))
            {
                return MapFromDomain((Domain.Video) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Video))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Video) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Video MapFromDomain(Domain.Video video)
        {
            var res = video == null ? null : new DALAppDTO.DomainEntityDTOs.Video
            {
                Id = video.Id,
                YouTubeUrl = video.YouTubeUrl,
                AuthorChannelLink = video.AuthorChannelLink,
                LocalPath = video.LocalPath,
                SongId = video.SongId,
                Song = SongMapper.MapFromDomain(video.Song)   
            };


            return res;
        }

        public static Domain.Video MapFromDAL(DALAppDTO.DomainEntityDTOs.Video video)
        {
            var res = video == null ? null : new Domain.Video
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

    }
}