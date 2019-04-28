using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongKeyMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.SongKey))
            {
                return MapFromDomain((Domain.SongKey) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.SongKey))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.SongKey) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.SongKey MapFromDomain(Domain.SongKey songKey)
        {
            var res = songKey == null ? null : new DALAppDTO.DomainEntityDTOs.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromDomain(songKey.Note)   
            };


            return res;
        }

        public static Domain.SongKey MapFromDAL(DALAppDTO.DomainEntityDTOs.SongKey songKey)
        {
            var res = songKey == null ? null : new Domain.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromDAL(songKey.Note)   
            };

            return res;
        }

    }
}