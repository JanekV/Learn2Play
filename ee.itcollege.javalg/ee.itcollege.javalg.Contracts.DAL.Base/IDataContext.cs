using System.Threading.Tasks;

namespace ee.itcollege.javalg.Contracts.DAL.Base
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}