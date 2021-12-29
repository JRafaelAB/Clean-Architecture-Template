using System.Threading;
using System.Threading.Tasks;
using Domain.DataAccess.UnitOfWork;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Moq;
using Xunit;

namespace UnitTests.DataAccess
{
    public class UnitOfWorkTest
    {
        private readonly Mock<CleanTemplateContext> _clockContext;
        private readonly IUnitOfWork _unitOfWork;
        
        public UnitOfWorkTest()
        {
            this._clockContext = new Mock<CleanTemplateContext>();
            this._unitOfWork = new UnitOfWork(this._clockContext.Object);
        }
        
        [Fact]
        public async Task TestingSucess_ValidateSave()
        {
            await this._unitOfWork.Save();
            this._clockContext.Verify(clock => clock.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }
        
        [Fact]
        public void TestingSucess_ValidateDispose()
        {
            this._unitOfWork.Dispose();
            this._clockContext.Verify(clock => clock.Dispose(), Times.Exactly(1));
            this._unitOfWork.Dispose();
            this._clockContext.Verify(clock => clock.Dispose(), Times.Exactly(1));
        }
    }
}
