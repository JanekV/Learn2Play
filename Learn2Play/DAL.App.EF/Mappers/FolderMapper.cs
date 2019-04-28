using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class FolderMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Folder))
            {
                return MapFromDomain((Domain.Folder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Folder))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Folder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Folder MapFromDomain(Domain.Folder folder)
        {
            var res = folder == null ? null : new DALAppDTO.DomainEntityDTOs.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
            };


            return res;
        }

        public static Domain.Folder MapFromDAL(DALAppDTO.DomainEntityDTOs.Folder folder)
        {
            var res = folder == null ? null : new Domain.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
            };

            return res;
        }

    }
}