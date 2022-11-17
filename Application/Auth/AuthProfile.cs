using Application.Auth.Dtos;
using AutoMapper;
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
