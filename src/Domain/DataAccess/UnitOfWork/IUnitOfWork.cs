using System.Threading.Tasks;

namespace Domain.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> Save();
        void Dispose();
    }
}
