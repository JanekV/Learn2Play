using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class TabMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Tab))
            {
                return MapFromDomain((Domain.Tab) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Tab))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Tab) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Tab MapFromDomain(Domain.Tab tab)
        {
            var res = tab == null ? null : new DALAppDTO.DomainEntityDTOs.Tab
            {
                Id = tab.Id,
                SongPart = tab.SongPart,
                StrummingPattern = tab.StrummingPattern,
                PicturePath = tab.PicturePath,
                Link = tab.Link,
                Author = tab.Author,
                VideoId = tab.VideoId,
                Video = VideoMapper.MapFromDomain(tab.Video) 
            };


            return res;
        }

        public static Domain.Tab MapFromDAL(DALAppDTO.DomainEntityDTOs.Tab tab)
        {
            var res = tab == null ? null : new Domain.Tab
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

    }
}