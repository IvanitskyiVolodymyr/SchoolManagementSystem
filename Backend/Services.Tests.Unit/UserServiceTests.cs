using Application.Interfaces;
using Application.MapperProfiles;
using Application.Services;
using AutoMapper;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Common.Exceptions;
using Domain.Core.Entities;
using Moq;
using Newtonsoft.Json;
using Services.Tests.Unit.MockRepositories;
using Services.Tests.Unit.MockServices;

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
                cfg.AddProfile(new AuthProfile());
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

            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetUserById(userId, userToReturn);


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

            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetUserById(userId, users.Where(u => u.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetUserById(userId));
        }

        [Theory]
        [InlineData("vova@gmail.com")]
        [InlineData("myroslav@gmail.com")]
        public async void GetUserByEmail_ValidCall(string email)
        {
            var users = GetUsers();
            var userToReturn = users.Where(u => u.Email == email).FirstOrDefault();

            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetUserByEmail(email, userToReturn);

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = JsonConvert.SerializeObject(_mapper.Map<UserDto>(userToReturn));
            var actual = JsonConvert.SerializeObject(await userService.GetUserByEmail(email));

            Assert.True(actual is not null);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("aaa@gmail.com")]
        [InlineData("")]
        [InlineData("aaa@bbb")]
        public async void GetUserByEmail_InvalidCall(string email)
        {
            var users = GetUsers();

            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetUserByEmail(email, users.Where(u => u.Email == email).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetUserByEmail(email));
        }

        [Fact]
        public async void UpdateUser_WithCorrectParams_ReturnsUserId()
        {
            User user = GetUsers()[0];
            user.FirstName = "Vasyl";

            var mockUserRepository = new MockUserRepository();
            mockUserRepository.UpdateUser(user, user.UserId);

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = user.UserId;
            var actual = await userService.UpdateUser(user);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void CreateStudent_WithCreateStudentDto_ReturnUserDtoWithStudentRole()
        {
            CreateStudentDto createStudentDto = new CreateStudentDto()
            {
                FirstName = "Vova",
                LastName = "Ivanitskyi",
                MiddleName = "Igorovich",
                Email = "vova@gmail.com",
                Address = "Address",
                BirthDate = new DateTime(2001, 9, 25),
                Gender = "M",
                PhoneNumber = "0964859635",
                JoinDate = DateTime.Now,
                Password = "IIvovaII",
                ClassId = 11,
                StudentCode = 111
            };

            var registeredDto = _mapper.Map<RegisterDto>(createStudentDto);
            registeredDto.RoleId = (int)Role.Student;

            UserDto? userDto = _mapper.Map<UserDto>(createStudentDto);
            userDto.UserId = 1;
            userDto.RoleId = (int)Role.Student;

            var mockAuthService = new MockAuthService();
            mockAuthService.Register(registeredDto, userDto);

            var insertStudent = new InsertStudentDto
            {
                ClassId = createStudentDto.ClassId,
                StudentCode = createStudentDto.StudentCode,
                UserId = 1
            };

            var mockStudentRepository = new MockStudentRepository();
            mockStudentRepository.CreateStudent(insertStudent, 1);


            IUserService userService = new UserService(null, _mapper, null, mockAuthService.Object, null, mockStudentRepository.Object);

            var expected = userDto;
            var actual = await userService.CreateStudent(createStudentDto);

            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));

        }

        [Fact]
        public async void CreateTeacher_WithCreateTeacherDto_ReturnUserDtoWithTeacherRole()
        {
            CreateTeacherDto createTeacherDto = new CreateTeacherDto()
            {
                FirstName = "Vova",
                LastName = "Ivanitskyi",
                MiddleName = "Igorovich",
                Email = "vova@gmail.com",
                Address = "Address",
                BirthDate = new DateTime(2001, 9, 25),
                Gender = "M",
                PhoneNumber = "0964859635",
                JoinDate = DateTime.Now,
                Password = "IIvovaII",
                ClassId = 11,
            };

            var registeredDto = _mapper.Map<RegisterDto>(createTeacherDto);
            registeredDto.RoleId = (int)Role.Teacher;

            UserDto? userDto = _mapper.Map<UserDto>(createTeacherDto);
            userDto.UserId = 1;
            userDto.RoleId = (int)Role.Teacher;

            var mockAuthService = new MockAuthService();
            mockAuthService.Register(registeredDto, userDto);

            var insertTeacher = new InsertTeacherDto
            {
                ClassId = createTeacherDto.ClassId,
                UserId = 1
            };

            var mockTeacherRepository = new MockTeacherRepository();
            mockTeacherRepository.CreateTeacher(insertTeacher, 1);


            IUserService userService = new UserService(null, _mapper, null, mockAuthService.Object, mockTeacherRepository.Object, null);

            var expected = userDto;
            var actual = await userService.CreateTeacher(createTeacherDto);

            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));

        }

        [Fact]
        public async void CreateParent_WithCreateParentDto_ReturnUserDtoWithParentRole()
        {
            CreateParentDto createParentDto = new CreateParentDto()
            {
                FirstName = "Vova",
                LastName = "Ivanitskyi",
                MiddleName = "Igorovich",
                Email = "vova@gmail.com",
                Address = "Address",
                BirthDate = new DateTime(2001, 9, 25),
                Gender = "M",
                PhoneNumber = "0964859635",
                JoinDate = DateTime.Now,
                Password = "IIvovaII",
                StudentIds = new List<int>() { 1, 2}
            };

            var registeredDto = _mapper.Map<RegisterDto>(createParentDto);
            registeredDto.RoleId = (int)Role.Parent;

            UserDto? userDto = _mapper.Map<UserDto>(createParentDto);
            userDto.UserId = 1;
            userDto.RoleId = (int)Role.Parent;

            var mockAuthService = new MockAuthService();
            mockAuthService.Register(registeredDto, userDto);

            var insertParent = new InsertParentDto
            {
                UserId = 1
            };

            var mockParentRepository = new MockParentRepository();
            mockParentRepository.CreateParent(insertParent, 1);


            IUserService userService = new UserService(null, _mapper, mockParentRepository.Object, mockAuthService.Object, null, null);

            var expected = userDto;
            var parentDto = await userService.CreateParentWithChildrenIds(createParentDto);
            var actual = parentDto.User;

            Assert.Equal(JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));

        }


        [Theory]
        [InlineData(1, (int)Role.Student)]
        public async void GetEntityIdWithRoleByUserId_WithCorrectStudentParameters_ReturnsEntity(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetStudentByUserId(userId, GetStudents().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = new EntityWithRoleDto { RoleId = roleId, EntityId = GetStudents().Where(s => s.UserId == userId).FirstOrDefault().StudentId};
            var actual = await userService.GetEntityIdWithRoleByUserId(userId, roleId);

            Assert.Equal(expected.RoleId, actual.RoleId);
            Assert.Equal(expected.EntityId, actual.EntityId);
        }

        [Theory]
        [InlineData(2, (int)Role.Parent)]
        public async void GetEntityIdWithRoleByUserId_WithCorrectParentParameters_ReturnsEntity(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();

            mockUserRepository.GetParentByUserId(userId, GetParents().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = new EntityWithRoleDto { RoleId = roleId, EntityId = GetParents().Where(s => s.UserId == userId).FirstOrDefault().ParentId };
            var actual = await userService.GetEntityIdWithRoleByUserId(userId, roleId);

            Assert.Equal(expected.RoleId, actual.RoleId);
            Assert.Equal(expected.EntityId, actual.EntityId);
        }

        [Theory]
        [InlineData(3,(int)Role.Teacher)]
        public async void GetEntityIdWithRoleByUserId_WithCorrectTeacherParameters_ReturnsEntity(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();

            mockUserRepository.GetTeacherByUserId(userId, GetTeachers().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            var expected = new EntityWithRoleDto { RoleId = roleId, EntityId = GetTeachers().Where(s => s.UserId == userId).FirstOrDefault().TeacherId };
            var actual = await userService.GetEntityIdWithRoleByUserId(userId, roleId);

            Assert.Equal(expected.RoleId, actual.RoleId);
            Assert.Equal(expected.EntityId, actual.EntityId);
        }

        [Theory]
        [InlineData(20, (int)Role.Student)]
        public async void GetEntityIdWithRoleByUserId_WithIncorrectStudentId_ThrowsNotFountException(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetStudentByUserId(userId, GetStudents().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetEntityIdWithRoleByUserId(userId, roleId));
        }

        [Theory]
        [InlineData(30, (int)Role.Parent)]
        public async void GetEntityIdWithRoleByUserId_WithIncorrectParentId_ThrowsNotFountException(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetParentByUserId(userId, GetParents().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetEntityIdWithRoleByUserId(userId, roleId));
        }

        [Theory]
        [InlineData(40, (int)Role.Teacher)]
        public async void GetEntityIdWithRoleByUserId_WithIncorrectTeacherId_ThrowsNotFountException(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetTeacherByUserId(userId, GetTeachers().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetEntityIdWithRoleByUserId(userId, roleId));
        }

        [Theory]
        [InlineData(40, 105)]
        public async void GetEntityIdWithRoleByUserId_WithIncorrectRole_ThrowsNotFountException(int userId, int roleId)
        {
            var user = GetUsers().Where(u => u.UserId == userId && u.RoleId == roleId).FirstOrDefault();
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetTeacherByUserId(userId, GetTeachers().Where(s => s.UserId == userId).FirstOrDefault());

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetEntityIdWithRoleByUserId(userId, roleId));
        }

        [Fact]
        public async void GetClassIdByStudentId_WithCorrectParameter_ReturnsClassId()
        {
            int studentID = 1;
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetClassIdByStudentId(studentID, 1);

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            int expected = 1;
            int actual = await userService.GetClassIdByStudentId(studentID);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetClassIdByUserId_WithIncorrectParameter_ThrowsNotFoundException()
        {
            int studentID = 99995;
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.GetClassIdByStudentId(studentID, default(int));

            IUserService userService = new UserService(mockUserRepository.Object, _mapper, null, null, null, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await userService.GetClassIdByStudentId(studentID));
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
                    RoleId = 2,
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
                    RoleId = 3,
                    UserId = 3,
                    PhoneNumber = "0964859637",
                    JoinDate = DateTime.Now
                }
            };

            return users;
        }

        private List<Student?> GetStudents()
        {
            return new List<Student?>() 
            {
                new Student
                {
                    UserId = 1,
                    ClassId = 1,
                    StudentCode = 111,
                    StudentId = 1
                }
            };
        }

        private List<Teacher?> GetTeachers()
        {
            return new List<Teacher?>()
            {
                new Teacher
                {
                    UserId = 3,
                    ClassId = 1,
                    TeacherId = 1
                }
            };
        }

        private List<Parent?> GetParents()
        {
            return new List<Parent?>()
            {
                new Parent
                {
                    UserId = 2,
                    ParentId = 1
                }
            };
        }
    }
}
