using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongInFolderMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.SongInFolder))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.SongInFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.SongInFolder))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.SongInFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.SongInFolder MapFromDAL(DAL.App.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new BLL.App.DTO.DomainEntityDTOs.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromDAL(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromDAL(songInFolder.Song)                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.SongInFolder MapFromBLL(BLL.App.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new DAL.App.DTO.DomainEntityDTOs.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromBLL(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromBLL(songInFolder.Song)  
            };

            return res;
        }

    }
}