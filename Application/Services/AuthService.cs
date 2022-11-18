using Application.Auth.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly string _passwordHashPepper;
        private readonly int _passwordHashCountOfIterations;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthService(IPasswordHasher passwordHasher,
                           IUserRepository userRepository,
                           IMapper mapper,
                           IConfiguration configuration,
                           ITokenService tokenService)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _passwordHashPepper = configuration.GetSection("PasswordConfig")["hashPepper"];
            _passwordHashCountOfIterations = Convert.ToInt32(configuration.GetSection("PasswordConfig")["countOfIterations"]);
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<AuthUserDto> Login(LoginDto userDto)
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

            return new AuthUserDto
            {
                User = _mapper.Map<UserDto>(userEntity),
                AccessToken = await _tokenService.GenerateJsonWebToken(userEntity)
            };
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
