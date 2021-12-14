using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> Save();
        void Dispose();
    }
}
