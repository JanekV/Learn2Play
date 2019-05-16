using System;
using ee.itcollege.javalg.Contracts.DAL.Base;

namespace ee.itcollege.javalg.Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceFactory<TUnitOfWork>
        where TUnitOfWork : IBaseUnitOfWork
    {
        void AddToCreationMethods<TService>(Func<TUnitOfWork, TService> creationMethod)
            where TService : class;

        Func<TUnitOfWork, object> GetServiceFactory<TService>();
        /* Too many generics
        
        Func<TUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IBaseEntity, new();
        */
    }

}