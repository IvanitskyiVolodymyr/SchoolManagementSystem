using Application.Interfaces;
using Common.Exceptions;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Domain.Core.Entities;
using ValidationException = Common.Exceptions.ValidationException;

namespace WebApi.Validators.Tasks
{
    public class TasksValidators
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParentRepository _parentRepository;
        public TasksValidators(ICurrentUserService currentUserService,
                               ITaskRepository taskRepository,
                               IUserRepository userRepository,
                               IParentRepository parentRepository)
        {
            _currentUserService = currentUserService;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _parentRepository = parentRepository;
        }

        public async Task CheckAccessByStudentTaskId(int studentTaskId)
        {
            int currentUserId = _currentUserService.GetCurrentUserId();
            var taskUserId = await _taskRepository.GetUserIdByStudentTaskId(studentTaskId);

            var currentRole = await _userRepository.GetRoleByUserId(currentUserId);

            switch (currentRole)
            {
                case Role.Teacher:
                    break;
                case Role.Director:
                    break;
                case Role.Parent:
                    var parent = await _userRepository.GetParentByUserId(currentUserId);

                    if (parent is null)
                        throw new NotAcceptableException();

                    var parentChildren = await _parentRepository.GetParentsStudents(parent.ParentId);

                    if (!parentChildren.Any(c => c.StudentUserId == taskUserId))
                        throw new NotAcceptableException();
                    break;
                case Role.Student:

                    if (currentUserId != taskUserId)
                        throw new NotAcceptableException();

                    break;
                default: throw new NotAcceptableException();

            }
        }

        public async Task CheckAccessByStudentId(int studentId)
        {
            int currentUserId = _currentUserService.GetCurrentUserId();

            var currentRole = await _userRepository.GetRoleByUserId(currentUserId);

            switch (currentRole)
            {
                case Role.Teacher:
                    break;
                case Role.Director:
                    break;
                case Role.Parent:
                    var parent = await _userRepository.GetParentByUserId(currentUserId);

                    if(parent is null)
                        throw new NotAcceptableException();

                    var parentChildren = await _parentRepository.GetParentsStudents(parent.ParentId);

                    if(!parentChildren.Any(c => c.StudentId == studentId))
                        throw new NotAcceptableException();
                    break;
                case Role.Student:
                    var currentStudent = await _userRepository.GetStudentByUserId(currentUserId);

                    if (currentStudent?.StudentId != studentId)
                        throw new NotAcceptableException();

                    break;
                default: throw new NotAcceptableException();

            }
        }

        public void ValidateGrade(int grade)
        {
            //check for max value
            if(grade < 0)
            {
                throw new ValidationException("Grade can not be less than 0");
            }

            if (grade > 100)
            {
                throw new ValidationException("Grade can not be above than 100");
            }
        }
    }
}
