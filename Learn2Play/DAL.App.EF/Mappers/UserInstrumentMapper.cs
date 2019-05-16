using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class UserInstrumentMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.UserInstrument))
            {
                return MapFromDomain((Domain.UserInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.UserInstrument))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.UserInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.UserInstrument MapFromDomain(Domain.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new DALAppDTO.DomainEntityDTOs.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDomain(userInstrument.Instrument),
                Comment = userInstrument.Comment 
            };


            return res;
        }

        public static Domain.UserInstrument MapFromDAL(DALAppDTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new Domain.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDAL(userInstrument.Instrument),
                Comment = userInstrument.Comment 
            };

            return res;
        }

    }
}