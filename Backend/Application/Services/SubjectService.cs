using Application.Interfaces;
using Common.Dtos.Subject;
using Common.Dtos.SubjectTeacher;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectTeacherRepository _subjectTeacherRepository;

        public SubjectService(ISubjectRepository subjectRepository, ISubjectTeacherRepository subjectTeacherRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectTeacherRepository = subjectTeacherRepository;
        }

        public async Task<int> AddTeacherToSubject(InsertSubjectTeacherDto subjectTeacherDto)
        {
            return await _subjectTeacherRepository.AddTeacherToSubject(subjectTeacherDto);
        }

        public async Task<int> CreateSubject(InsertSubjectDto subjectDto)
        {
            return await _subjectRepository.InsertSubject(subjectDto);
        }

        public async Task<IEnumerable<int>> CreateSubjects(IEnumerable<InsertSubjectDto> subjects)
        {
            return await _subjectRepository.InsertSubjects(subjects);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _subjectRepository.GetAllSubjects();
        }
    }
}
