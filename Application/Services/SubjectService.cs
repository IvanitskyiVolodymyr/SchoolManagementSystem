using Application.Interfaces;
using Common.Dtos.Subject;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
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
