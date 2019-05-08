using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class VideoMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Video))
            {
                return MapFromBLL((internalDTO.Video) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Video))
            {
                return MapFromExternal((externalDTO.Video) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Video MapFromBLL(internalDTO.Video video)
        {
            var res = video == null ? null : new externalDTO.Video
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

        public static internalDTO.Video MapFromExternal(externalDTO.Video video)
        {
            var res = video == null ? null : new internalDTO.Video
            {
                Id = video.Id,
                YouTubeUrl = video.YouTubeUrl,
                AuthorChannelLink = video.AuthorChannelLink,
                LocalPath = video.LocalPath,
                SongId = video.SongId,
                Song = SongMapper.MapFromExternal(video.Song) 
            };

            return res;
        }

    }
}