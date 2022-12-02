using Domain.Core.Entities;

namespace Common.Dtos.ClassSubjectGrade
{
    public class InsertClassSubjectGradeDto
    {
        public GradeType GradeType { get; set; }
        public int ClassSubjectId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
    }
}
