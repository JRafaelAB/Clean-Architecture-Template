using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.DataAccess.Repositories;
using Dommel;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess.Repositories
{
    public abstract class BaseRepository<TDbo> : IBaseRepository<TDbo> where TDbo : class
    {
        private readonly CleanTemplateContext _context;

        protected BaseRepository(CleanTemplateContext context)
        {
            _context = context;
        }

        public async Task Add(TDbo tDbo)
        {
            await this._context.Connection.InsertAsync(tDbo);
        }
        
        public async Task<TDbo?> GetFirstByExpression(Expression<Func<TDbo, bool>> expression)
        {
            var dboList = await GetByExpression(expression);
            return dboList.FirstOrDefault();
        }
        
        public async Task<IEnumerable<TDbo>> GetByExpression(Expression<Func<TDbo, bool>> expression)
        {
            return await this._context.Connection.SelectAsync(expression);
        }
    }
}
