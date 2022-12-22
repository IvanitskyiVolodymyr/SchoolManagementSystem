using Application.Interfaces;
using Common.Exceptions;
using Common.Exceptions.Auth;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public bool IsAuthorized { get; }

        private readonly IUserRepository _userRepository;
        private string accessToken;
        private ITokenService _tokenService;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            ITokenService tokenService
        )
        {
            _userRepository = userRepository;
            accessToken = httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
            _tokenService = tokenService;
        }

        public int GetCurrentUserId()
        {
            var id = _tokenService.GetUserIdFromToken(accessToken.Replace("Bearer ", ""));
            return id;
        }
    }
}
