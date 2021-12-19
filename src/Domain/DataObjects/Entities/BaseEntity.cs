using System.Threading.Tasks;
using AutoMapper;
using Domain.DataAccess.Repositories;

namespace Domain.DataObjects.Entities
{
    public abstract class BaseEntity<TDbo>
    {
        protected readonly IMapper Mapper;
        protected readonly IBaseRepository<TDbo> Repository;

        protected BaseEntity(IMapper mapper, IBaseRepository<TDbo> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }
        
        public async Task AddToDatabase()
        {
            TDbo dbo = Mapper.Map<TDbo>(this);
            await Repository.Add(dbo);
        }
    }
}
