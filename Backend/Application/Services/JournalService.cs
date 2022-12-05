using Application.Interfaces;
using Common.Dtos.ClassSubjectGrade;
using Common.Dtos.Grades;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class JournalService : IJournalService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IClassSubjectGradeRepository _classSubjectGradeRepository;

        public JournalService(IGradeRepository gradeRepository, IClassSubjectGradeRepository classSubjectGradeRepository)
        {
            _gradeRepository = gradeRepository;
            _classSubjectGradeRepository = classSubjectGradeRepository;
        }

        public async Task<IEnumerable<ClassSubjectGrade>> GetAllFinalGradesByClassId(int studentId, int classId)
        {
            return await _classSubjectGradeRepository.GetAllGradesByClassId(studentId, classId);
        }

        public async Task<IEnumerable<ClassSubjectGrade>> GetAllFinalGradesByClassSubjectId(int studentId, int classSubjectId)
        {
            return await _classSubjectGradeRepository.GetGradesByClassSubjectId(studentId, classSubjectId);
        }

        public async Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId)
        {
            return await _gradeRepository.GetAllGradesWithSubjectsForStudent(studentId);
        }

        public async Task<int> InsertClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return await _classSubjectGradeRepository.InsertClassSubjectGrade(subjectGradeDto);
        }

        public async Task<int> UpdateClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return await _classSubjectGradeRepository.UpdateClassSubjectGrade(subjectGradeDto);
        }
    }
}
