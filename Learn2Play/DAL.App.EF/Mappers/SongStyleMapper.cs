using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongStyleMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.SongStyle))
            {
                return MapFromDomain((Domain.SongStyle) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.SongStyle))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.SongStyle) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.SongStyle MapFromDomain(Domain.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new DALAppDTO.DomainEntityDTOs.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromDomain(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromDomain(songStyle.Style)  
            };


            return res;
        }

        public static Domain.SongStyle MapFromDAL(DALAppDTO.DomainEntityDTOs.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new Domain.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromDAL(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromDAL(songStyle.Style)  
            };

            return res;
        }

    }
}