using System.Threading.Tasks;

namespace Domain.DataAccess.Repositories
{
    public interface IBaseRepository<in TDbo>
    {
        Task Add(TDbo entity);
    }
}
