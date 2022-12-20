using Application.Interfaces;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockServices
{
    public class MockAuthService : Mock<IAuthService>
    {
        public void Register(RegisterDto registerUserDto, UserDto output)
        {
            Setup(x => x.Register(It.Is<RegisterDto>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(registerUserDto))))
                .ReturnsAsync(output);
        }
    }
}
