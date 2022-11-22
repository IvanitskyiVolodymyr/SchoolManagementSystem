using Application.Interfaces;
using AutoMapper;
using Common.Dtos.Users;
using Common.Exceptions;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateUser(InsertUserDto user)
        {
            return await _userRepository.InsertUser(user);
        }

        public async Task<int> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if(user is null)
            {
                throw new NotFoundException(typeof(User), "Id", id.ToString());
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user is null)
            {
                throw new NotFoundException(typeof(User), "Email", email);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
