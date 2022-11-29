﻿using Application.Interfaces;
using Common.Dtos.Tasks;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Common.Dtos.StudentTask;
using Common.Dtos.StudentTaskAttachment;
using Common.Exceptions;
using AutoMapper;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to)
        {
            return await _taskRepository.GetTasksByStudentId(studentId, from, to);
        }

        public async Task<int> InsertTaskForStudentsByScheduleId(InsertTaskDto taskDto)
        {
            return await _taskRepository.InsertTaskForScheduleId(taskDto);
        }

        public async Task<int> InsertTaskForStudent(InsertTaskDto taskDto, int studentId)
        {
            var taskId = await _taskRepository.InsertTask(taskDto);
            return await _taskRepository.InsertStudentTask(new InsertStudentTaskDto { StudentId = studentId, TaskId = taskId });

        }

        public async Task<int> UpdateTask(UpdateTaskDto task)
        {
            return await _taskRepository.UpdateTask(task);
        }

        public async Task<int> SubmitStudentTask(int studentTaskId, List<StudentTaskAttachmentDto> attachments)
        {
            var studentTask = await GetModelUpdateStudentTask(studentTaskId);

            studentTask.IsDone = true;
            var studentTaskAttachments = attachments.Select(a => new InsertStudentTaskAttachmentDto { FileUrl = a.FileUrl, StudentTaskId = studentTaskId }).ToList();
            return await _taskRepository.UpdateStudentTaskWithAttachments(studentTask, studentTaskAttachments);
        }

        public async Task<int> MarkStudentTaskAsChecked(int studentTaskId)
        {
            var studentTask = await GetModelUpdateStudentTask(studentTaskId);

            studentTask.IsChecked = true;
            return await _taskRepository.UpdateStudentTask(studentTask);
        }

        public async Task<int> MarkStudentTaskAsNeededToBeRedone(int studentTaskId)
        {
            var studentTask = await GetModelUpdateStudentTask(studentTaskId);

            studentTask.IsNeededToBeRedone = true;
            return await _taskRepository.UpdateStudentTask(studentTask);
        }

        private async Task<UpdateStudentTaskDto> GetModelUpdateStudentTask(int studentTaskId)
        {
            var studentTask = await _taskRepository.GetStudentTaskById(studentTaskId);
            if (studentTask is null)
            {
                throw new NotFoundException(typeof(StudentTask), "StudentTaskId", studentTaskId.ToString());
            }
            return _mapper.Map<UpdateStudentTaskDto>(studentTask);
        }

        public async Task<IEnumerable<ResponseTeacherTaskDto>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId)
        {
            return await _taskRepository.GetUncheckedTasksByTeacherIdSubjectIdClassId(teacherId, subjectId, classId);
        }

        public async Task<IEnumerable<StudentTaskAttachmentDto>> GetStudentTaskAttachments(int studentTaskId)
        {
            return await _taskRepository.GetStudentTaskAttachments(studentTaskId);
        }
    }
}
