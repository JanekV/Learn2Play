using System;

namespace ee.itcollege.javalg.Contracts.DAL.Base
{
    public interface IDomainEntity: IDomainEntity<int>
    {
       
    }

    public interface IDomainEntity<TKey> where TKey: IComparable
    {
        TKey Id { get; set;}
    }


}