using AutoMapper;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<CreateParentDto, RegisterDto>();
            CreateMap<CreateStudentDto, RegisterDto>();
            CreateMap<CreateTeacherDto, RegisterDto>();

            CreateMap<CreateParentDto, InsertParentDto>();
            CreateMap<CreateTeacherDto, InsertTeacherDto>();
            CreateMap<CreateStudentDto, InsertStudentDto>();

            CreateMap<User, InsertUserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateStudentDto, UserDto>();
            CreateMap<CreateTeacherDto, UserDto>();
            CreateMap<CreateParentDto, UserDto>();
        }
    }
}
