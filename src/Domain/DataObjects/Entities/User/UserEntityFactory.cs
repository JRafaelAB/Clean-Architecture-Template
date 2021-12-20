using AutoMapper;
using Domain.DataAccess.Repositories;
using Domain.DataObjects.Database;
using Domain.DataObjects.Entities.Factories;
using Domain.DataObjects.Models.Requests;

namespace Domain.DataObjects.Entities.User
{
    public class UserEntityFactory : IUserEntityFactory
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserEntityFactory(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public UserEntity CreateNew(PostUserRequest request)
        {
            return new UserEntity( _mapper, _repository, request.Name, request.Login, request.Password);
        }
        
        public UserEntity CreateNew(UserDbo dbo)
        {
            return new UserEntity(_mapper, _repository, dbo.Name, dbo.Login, dbo.Password, dbo.Salt);
        }
    }
}
