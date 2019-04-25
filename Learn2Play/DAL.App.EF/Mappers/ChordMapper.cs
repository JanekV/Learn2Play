using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ChordMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Chord))
            {
                return MapFromDomain((Domain.Chord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Chord))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Chord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Chord MapFromDomain(Domain.Chord chord)
        {
            var res = chord == null ? null : new DALAppDTO.DomainEntityDTOs.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };


            return res;
        }

        public static Domain.Chord MapFromDAL(DALAppDTO.DomainEntityDTOs.Chord chord)
        {
            var res = chord == null ? null : new Domain.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };

            return res;
        }

    }
}