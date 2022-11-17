using Application.Auth.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly string _passwordHashPepper;
        private readonly int _passwordHashCountOfIterations;
        private readonly IMapper _mapper;
        public AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _passwordHashPepper = "secretText";
            _passwordHashCountOfIterations = 4;
            _mapper = mapper;
        }
        public async Task<UserDto> Login(LoginDto userDto)
        {
            var userEntity = await _userRepository.GetUserByEmail(userDto.Email);

            if (userEntity is null)
            {
                //Create custom exception
                throw new Exception("Invalid user data");
            }

            var passwordHash = _passwordHasher.CalculateHash(userDto.Password,
                                                              userEntity.PasswordSalt,
                                                              _passwordHashPepper,
                                                              _passwordHashCountOfIterations);
            if (passwordHash != userEntity.PasswordHash)
            {
                //Create custom exception
                throw new Exception("Username or password did not match.");
            }

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<UserDto> Register(RegisterDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            user.PasswordSalt = _passwordHasher.GenerateSalt();
            user.PasswordHash = _passwordHasher.CalculateHash(userDto.Password,
                                                              user.PasswordSalt,
                                                              _passwordHashPepper,
                                                              _passwordHashCountOfIterations);

            var id = await _userRepository.InsertUser(user);

            var userEntity = await _userRepository.GetUserById(id);

            return _mapper.Map<UserDto>(userEntity);
        }
    }
}
