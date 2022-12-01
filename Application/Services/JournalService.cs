using Application.Interfaces;
using Common.Dtos.Grades;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class JournalService : IJournalService
    {
        private readonly IGradeRepository _gradeRepository;

        public JournalService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId)
        {
            return await _gradeRepository.GetAllGradesWithSubjectsForStudent(studentId);
        }
    }
}
