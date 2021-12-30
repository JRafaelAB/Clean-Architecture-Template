using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.DataAccess.Repositories
{
    public interface IBaseRepository<TDbo>
    {
        Task Add(TDbo tDbo);
        Task<TDbo?> GetFirstByExpression(Expression<Func<TDbo, bool>> expression);
        Task<IEnumerable<TDbo>> GetByExpression(Expression<Func<TDbo, bool>> expression);
    }
}
