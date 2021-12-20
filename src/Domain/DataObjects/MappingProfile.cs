using AutoMapper;
using Domain.DataObjects.Database;
using Domain.DataObjects.Entities.User;

namespace Domain.DataObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            EntityToDboProfile();
        }

        public void EntityToDboProfile()
        {
            CreateMap<UserEntity, UserDbo>();
        }
    }
}
