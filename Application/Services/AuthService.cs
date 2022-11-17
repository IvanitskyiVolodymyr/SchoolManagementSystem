using Application.Auth.Dtos;
using Application.Interfaces;
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
        public AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _passwordHashPepper = "secretText";
            _passwordHashCountOfIterations = 4;
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

            //Add mapper
            return new UserDto()
            {
                UserId = userEntity.UserId,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                Address = userEntity.Address,
                Gender = userEntity.Gender,
                JoinDate = userEntity.JoinDate,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                PhoneNumber = userEntity.PhoneNumber,
                RoleId = userEntity.RoleId,
                AvatarUrl = userEntity.AvatarUrl
            };
        }

        public async Task<UserDto> Register(RegisterDto userDto)
        {
            //Add maper
            User user = new User()
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Address = userDto.Address,
                PhoneNumber = userDto.PhoneNumber,
                BirthDate = userDto.BirthDate,
                JoinDate = userDto.JoinDate,
                Gender = userDto.Gender,
                RoleId = userDto.RoleId
            };
            user.PasswordSalt = _passwordHasher.GenerateSalt();
            user.PasswordHash = _passwordHasher.CalculateHash(userDto.Password,
                                                              user.PasswordSalt,
                                                              _passwordHashPepper,
                                                              _passwordHashCountOfIterations);

            var id = await _userRepository.InsertUser(user);

            var userEntity = await _userRepository.GetUserById(id);

            //Add mapper
            return new UserDto()
            {
                UserId = userEntity.UserId,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                Address = userEntity.Address,
                Gender = userEntity.Gender,
                JoinDate = userEntity.JoinDate,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                PhoneNumber = userEntity.PhoneNumber,
                RoleId = userEntity.RoleId,
                AvatarUrl = userEntity.AvatarUrl
            };
        }
    }
}
