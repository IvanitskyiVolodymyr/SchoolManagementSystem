
using Domain.Core.Entities;

namespace Common.Dtos.Grades
{
    public class SubjectGradesDto
    {
        public int ClassSubjectId { get; set; }
        public string SubjectName { get; set; }

        public IList<Grade> Grades { get; set; }
    }
}
