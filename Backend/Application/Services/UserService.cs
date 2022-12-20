using Application.Interfaces;
using AutoMapper;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Common.Exceptions;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IParentRepository _parentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper,
                           IParentRepository parentRepository,
                           IAuthService authService,
                           ITeacherRepository teacherRepository,
                           IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _parentRepository = parentRepository;
            _authService = authService;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<int> UpdateUser(User user)
        {
            //Added check. Only User can edit their-self or admin
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

        public async Task<UserDto> CreateStudent(CreateStudentDto student)
        {
            var registeredDto = _mapper.Map<RegisterDto>(student);
            registeredDto.RoleId = (int)Role.Student;
            var registeredUser = await _authService.Register(registeredDto);

            var insertedStudent = _mapper.Map<InsertStudentDto>(student);
            insertedStudent.UserId = registeredUser.UserId;

            await _studentRepository.CreateStudent(insertedStudent);

            return registeredUser;
        }

        public async Task<ResponseParentDto> CreateParentWithChildrenIds(CreateParentDto parent)
        {
            var registerDto = _mapper.Map<RegisterDto>(parent);
            registerDto.RoleId = (int)Role.Parent;
            var registeredUser = await _authService.Register(registerDto);

            var insertedParent = _mapper.Map<InsertParentDto>(parent);
            insertedParent.UserId = registeredUser.UserId;

            var parentId = await _parentRepository.CreateParent(insertedParent);

            foreach(var studentId in parent.StudentIds)
            {
                await _parentRepository.CreateParentStudent(parentId, studentId);
            }

            return new ResponseParentDto
            {
                User = registeredUser,
                ParentId = parentId,
                StudentIds = parent.StudentIds
            };
        }

        public async Task<UserDto> CreateTeacher(CreateTeacherDto teacher)
        {
            var registeredDto = _mapper.Map<RegisterDto>(teacher);
            registeredDto.RoleId = (int)Role.Teacher;
            var registeredUser = await _authService.Register(registeredDto);

            var insertedTeacher = _mapper.Map<InsertTeacherDto>(teacher);
            insertedTeacher.UserId = registeredUser.UserId;

            await _teacherRepository.CreateTeacher(insertedTeacher);

            return registeredUser;
        }

        public async Task<EntityWithRoleDto> GetEntityIdWithRoleByUserId(int userId, int roleId)
        {
            EntityWithRoleDto result = new EntityWithRoleDto();
            result.RoleId = roleId;

            switch (roleId)
            {
                case (int)Role.Student:
                    var student = await _userRepository.GetStudentByUserId(userId);

                    if (student is null)
                        throw new NotFoundException(typeof(Student), "UserId", userId.ToString());

                    result.EntityId = student.StudentId;
                    break;
                case (int)Role.Parent:
                    var parent = await _userRepository.GetParentByUserId(userId);

                    if (parent is null)
                        throw new NotFoundException(typeof(Parent), "UserId", userId.ToString());

                    result.EntityId = parent.ParentId;
                    break;
                case (int)Role.Teacher:
                    var teacher = await _userRepository.GetTeacherByUserId(userId);

                    if (teacher is null)
                        throw new NotFoundException(typeof(Teacher), "UserId", userId.ToString());

                    result.EntityId = teacher.TeacherId;
                    break;
                default:
                    throw new NotFoundException(typeof(Role), "RoleId", roleId.ToString());
            }

            return result;
        }
    }
}
