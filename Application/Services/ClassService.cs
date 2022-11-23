using Application.Interfaces;
using Common.Dtos.Class;
using Common.Dtos.ClassSubject;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IClassSubjectRepository _classSubjectRepository;

        public ClassService(IClassRepository classRepository, IClassSubjectRepository classSubjectRepository)
        {
            _classRepository = classRepository;
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<IEnumerable<int>> AddSubjectsToClass(IEnumerable<InsertClassSubjectDto> classSubjects)
        {
            return await _classSubjectRepository.InsertClassSubjects(classSubjects);
        }

        public async Task<int> AddSubjectToClass(InsertClassSubjectDto classSubjectDto)
        {
            return await _classSubjectRepository.InsertClassSubject(classSubjectDto);
        }

        public async Task<int> CreateClass(InsertClassDto classDto)
        {
            return await _classRepository.InsertClass(classDto);
        }

        public async Task<IEnumerable<int>> CreateClasses(IEnumerable<InsertClassDto> classesDto)
        {
            return await _classRepository.InsertClasses(classesDto);
        }
    }
}
