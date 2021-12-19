using System;
using System.Threading.Tasks;
using Domain.DataAccess.UnitOfWork;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ClockContext _clockContext;
        private bool _disposed;

        public UnitOfWork(ClockContext clockContext) => this._clockContext = clockContext;

        public void Dispose() => this.Dispose(true);

        public async Task<int> Save()
        {
            int affectedRows = await this._clockContext
                .SaveChangesAsync();
            return affectedRows;
        }
        
        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._clockContext.Dispose();
            }

            this._disposed = true;
        }
    }
}
