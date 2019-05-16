using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class UserFolderMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.UserFolder))
            {
                return MapFromDomain((Domain.UserFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.UserFolder))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.UserFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.UserFolder MapFromDomain(Domain.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new DALAppDTO.DomainEntityDTOs.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromDomain(userFolder.Folder),
                Comment = userFolder.Comment  
            };


            return res;
        }

        public static Domain.UserFolder MapFromDAL(DALAppDTO.DomainEntityDTOs.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new Domain.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromDAL(userFolder.Folder),
                Comment = userFolder.Comment  
            };

            return res;
        }

    }
}