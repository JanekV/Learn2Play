using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class NoteMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Note))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Note) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Note))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Note) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Note MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Note note)
        {
            var res = note == null ? null : new BLL.App.DTO.DomainEntityDTOs.Note
            {
                Id = note.Id,
                Name = note.Name
                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Note MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Note note)
        {
            var res = note == null ? null : new DAL.App.DTO.DomainEntityDTOs.Note
            {
                Id = note.Id,
                Name = note.Name
            };

            return res;
        }

    }
}