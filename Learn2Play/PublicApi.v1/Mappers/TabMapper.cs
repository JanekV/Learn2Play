using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class TabMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Tab))
            {
                return MapFromBLL((internalDTO.Tab) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Tab))
            {
                return MapFromExternal((externalDTO.Tab) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Tab MapFromBLL(internalDTO.Tab tab)
        {
            var res = tab == null ? null : new externalDTO.Tab
            {
                Id = tab.Id,
                SongPart = tab.SongPart,
                StrummingPattern = tab.StrummingPattern,
                PicturePath = tab.PicturePath,
                Link = tab.Link,
                Author = tab.Author,
                VideoId = tab.VideoId,
                Video = VideoMapper.MapFromBLL(tab.Video)            
            };


            return res;
        }

        public static internalDTO.Tab MapFromExternal(externalDTO.Tab tab)
        {
            var res = tab == null ? null : new internalDTO.Tab
            {
                Id = tab.Id,
                SongPart = tab.SongPart,
                StrummingPattern = tab.StrummingPattern,
                PicturePath = tab.PicturePath,
                Link = tab.Link,
                Author = tab.Author,
                VideoId = tab.VideoId,
                Video = VideoMapper.MapFromExternal(tab.Video) 
            };

            return res;
        }

    }
}