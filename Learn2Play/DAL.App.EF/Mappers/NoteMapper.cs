using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class NoteMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Note))
            {
                return MapFromDomain((Domain.Note) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Note))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Note) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Note MapFromDomain(Domain.Note note)
        {
            var res = note == null ? null : new DALAppDTO.DomainEntityDTOs.Note
            {
                Id = note.Id,
                Name = note.Name
                
            };


            return res;
        }

        public static Domain.Note MapFromDAL(DALAppDTO.DomainEntityDTOs.Note note)
        {
            var res = note == null ? null : new Domain.Note
            {
                Id = note.Id,
                Name = note.Name
            };

            return res;
        }

    }
}