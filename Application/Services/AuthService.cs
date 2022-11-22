using Application.Auth.Dtos;
using Application.Interfaces;
using AutoMapper;
using Common.Dtos.Users;
using Common.Exceptions.Auth;
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
        private readonly int _refreshTokenExpirationInDays;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public AuthService(IPasswordHasher passwordHasher,
                           IUserRepository userRepository,
                           IMapper mapper,
                           IConfiguration configuration,
                           ITokenService tokenService,
                           IRefreshTokenRepository refreshTokenRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _passwordHashPepper = configuration.GetSection("PasswordConfig")["hashPepper"];
            _passwordHashCountOfIterations = Convert.ToInt32(configuration.GetSection("PasswordConfig")["countOfIterations"]);
            _refreshTokenExpirationInDays = Convert.ToInt32(configuration.GetSection("JwtConfig")["refreshTokenExpiresInDays"]);
            _mapper = mapper;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
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

            return await CreateAuthUser(userEntity);
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

        public async Task<AuthUserDto> RefreshToken(TokenModel token)
        {
            int userId = _tokenService.GetUserIdFromToken(token.AccessToken);

            var user = await _userRepository.GetUserById(userId);

            if(user is null)
            {
                //Create custom exception
                throw new Exception("User not found");
            }

            var refreshToken = await _refreshTokenRepository.GetRefreshToken(token.RefreshToken);

            if(refreshToken is null)
            {
                throw new InvalidRefreshTokenException();
            }

            if(DateTime.UtcNow >= refreshToken.Expires)
            {
                await _refreshTokenRepository.DeleteRefreshToken(refreshToken.RefreshTokenId);

                throw new ExpiredRefreshTokenException();
            }

            return await CreateAuthUser(user);
        }

        public async Task RevokeRefreshToken(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetRefreshToken(token);

            if (refreshToken is null)
            {
                throw new InvalidRefreshTokenException();
            }

            await _refreshTokenRepository.DeleteRefreshToken(refreshToken.RefreshTokenId);
        }

        private async Task<AuthUserDto> CreateAuthUser(User user)
        {
            return new AuthUserDto
            {
                User = _mapper.Map<UserDto>(user),
                Tokens = await GenerateTokens(user)
            };
        }

        private async Task<TokenModel> GenerateTokens(User user)
        {
            string refreshToken = _tokenService.GenerateRefreshToken();

            await _refreshTokenRepository.InsertRefreshToken(
                new RefreshToken
                {
                    Token = refreshToken,
                    UserId = user.UserId,
                    Expires = DateTime.UtcNow.AddDays(_refreshTokenExpirationInDays)
                });

            return new TokenModel
            {
                AccessToken = await _tokenService.GenerateJsonWebToken(user),
                RefreshToken = refreshToken
            };
        }
    }
}
