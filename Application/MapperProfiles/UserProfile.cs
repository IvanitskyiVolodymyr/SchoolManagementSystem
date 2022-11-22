using AutoMapper;
using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, InsertUserDto>();
            CreateMap<InsertUserDto, User>();
        }
    }
}
