using System;
using System.Threading.Tasks;
using Domain.DataAccess.UnitOfWork;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CleanTemplateContext _cleanTemplateContext;
        private bool _disposed;

        public UnitOfWork(CleanTemplateContext cleanTemplateContext) => this._cleanTemplateContext = cleanTemplateContext;

        public void Dispose() => this.Dispose(true);

        public async Task<int> Save()
        {
            int affectedRows = await this._cleanTemplateContext
                .SaveChangesAsync();
            return affectedRows;
        }
        
        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._cleanTemplateContext.Dispose();
            }

            this._disposed = true;
        }
    }
}
