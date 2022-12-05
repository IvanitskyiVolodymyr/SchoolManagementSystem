using AutoMapper;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.MapperProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
