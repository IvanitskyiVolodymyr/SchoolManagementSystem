using AutoMapper;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.Auth
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<RegisterDto, User>();
        }
    }
}
