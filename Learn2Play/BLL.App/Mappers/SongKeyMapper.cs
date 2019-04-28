using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongKeyMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.SongKey))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.SongKey) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.SongKey))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.SongKey) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.SongKey MapFromDAL(DAL.App.DTO.DomainEntityDTOs.SongKey songKey)
        {
            var res = songKey == null ? null : new BLL.App.DTO.DomainEntityDTOs.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromDAL(songKey.Note)                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.SongKey MapFromBLL(BLL.App.DTO.DomainEntityDTOs.SongKey songKey)
        {
            var res = songKey == null ? null : new DAL.App.DTO.DomainEntityDTOs.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromBLL(songKey.Note) 
            };

            return res;
        }

    }
}