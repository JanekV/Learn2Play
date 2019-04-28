using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongStyleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.SongStyle))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.SongStyle) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.SongStyle))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.SongStyle) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.SongStyle MapFromDAL(DAL.App.DTO.DomainEntityDTOs.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new BLL.App.DTO.DomainEntityDTOs.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromDAL(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromDAL(songStyle.Style)               
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.SongStyle MapFromBLL(BLL.App.DTO.DomainEntityDTOs.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new DAL.App.DTO.DomainEntityDTOs.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromBLL(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromBLL(songStyle.Style)  
            };

            return res;
        }

    }
}