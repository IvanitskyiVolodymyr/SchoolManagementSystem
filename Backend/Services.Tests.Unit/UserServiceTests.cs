using Application.Interfaces;
using Application.MapperProfiles;
using Application.Services;
using AutoMapper;
using Common.Dtos.Users;
using Common.Exceptions;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit
{
    public class UserServiceTests
    {
        private IMapper _mapper;
        public UserServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetUserById_ValidCall(int userId)
        {
            var users = GetUsers();
            var userToReturn = users.Where(u => u.UserId == userId).FirstOrDefault();

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetUserById(userId)).ReturnsAsync(userToReturn);


            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = JsonConvert.SerializeObject(_mapper.Map<UserDto>(userToReturn));
            var actual = JsonConvert.SerializeObject(await userService.GetUserById(userId));

            Assert.True(actual is not null);
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public async void GetUserById_InvalidCall(int userId)
        {
            var users = GetUsers();

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetUserById(userId))
                .ReturnsAsync(users.Where(u => u.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetUserById(userId));

        }



        private List<User> GetUsers()
        {
            var users = new List<User>() 
            {
                new User
                {
                    FirstName = "Vova",
                    LastName = "Ivanitskyi",
                    MiddleName = "Igorovich",
                    Email = "vova@gmail.com",
                    Address = "Address",
                    AvatarUrl = "none",
                    BirthDate = new DateTime(2001,9,25),
                    Gender = "M",
                    RoleId = 1,
                    UserId = 1,
                    PhoneNumber = "0964859635",
                    JoinDate = DateTime.Now
                },
                new User
                {
                    FirstName = "Myroslav",
                    LastName = "Ivanitskyi",
                    MiddleName = "Igorovich",
                    Email = "myroslav@gmail.com",
                    Address = "Address",
                    AvatarUrl = "none",
                    BirthDate = new DateTime(2003,10,31),
                    Gender = "M",
                    RoleId = 1,
                    UserId = 2,
                    PhoneNumber = "0964859636",
                    JoinDate = DateTime.Now
                },
                new User
                {
                    FirstName = "Zenoviy",
                    LastName = "Sergo",
                    MiddleName = "Sergiv",
                    Email = "zenovyi@gmail.com",
                    Address = "Address2",
                    AvatarUrl = "none",
                    BirthDate = new DateTime(2005,8, 14),
                    Gender = "M",
                    RoleId = 1,
                    UserId = 3,
                    PhoneNumber = "0964859637",
                    JoinDate = DateTime.Now
                }
            };

            return users;

        }
    }
}
