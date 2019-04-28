using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class UserFolderMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.UserFolder))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.UserFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.UserFolder))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.UserFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.UserFolder MapFromDAL(DAL.App.DTO.DomainEntityDTOs.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new BLL.App.DTO.DomainEntityDTOs.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromDAL(userFolder.Folder),
                Comment = userFolder.Comment           
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.UserFolder MapFromBLL(BLL.App.DTO.DomainEntityDTOs.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new DAL.App.DTO.DomainEntityDTOs.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromBLL(userFolder.Folder),
                Comment = userFolder.Comment  
            };

            return res;
        }

    }
}