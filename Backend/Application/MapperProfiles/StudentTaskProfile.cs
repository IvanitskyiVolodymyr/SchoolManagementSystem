using AutoMapper;
using Common.Dtos.StudentTask;
using Common.Dtos.Tasks;
using Domain.Core.Entities;

namespace Application.MapperProfiles
{
    public class StudentTaskProfile : Profile
    {
        public StudentTaskProfile()
        {
            CreateMap<StudentTask, UpdateStudentTaskDto>();
            CreateMap<ResponseTaskWithGradeDto, ResponseTaskWithGradeAndAttachmentsDto>();
            CreateMap<TaskWithGradeDto, ResponseTaskWithGradeAndAttachmentsDto>();
        }
    }
}
