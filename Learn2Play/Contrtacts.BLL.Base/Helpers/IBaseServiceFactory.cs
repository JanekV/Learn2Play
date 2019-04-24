using System;
using Contracts.DAL.Base;

namespace Contrtacts.BLL.Base.Helpers
{
    public interface IBaseServiceFactory<TUnitOfWork>
        where TUnitOfWork : IBaseUnitOfWork
    {
        void AddToCreationMethods<TService>(Func<TUnitOfWork, TService> creationMethod)
            where TService : class;

        Func<TUnitOfWork, object> GetServiceFactory<TService>();

        Func<TUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IBaseEntity, new();
    }

}