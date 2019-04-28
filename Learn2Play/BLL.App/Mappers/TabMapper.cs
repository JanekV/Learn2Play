using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class TabMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Tab))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Tab) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Tab))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Tab) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Tab MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Tab tab)
        {
            var res = tab == null ? null : new BLL.App.DTO.DomainEntityDTOs.Tab
            {
                Id = tab.Id,
                SongPart = tab.SongPart,
                StrummingPattern = tab.StrummingPattern,
                PicturePath = tab.PicturePath,
                Link = tab.Link,
                Author = tab.Author,
                VideoId = tab.VideoId,
                Video = VideoMapper.MapFromDAL(tab.Video)            
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Tab MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Tab tab)
        {
            var res = tab == null ? null : new DAL.App.DTO.DomainEntityDTOs.Tab
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

    }
}