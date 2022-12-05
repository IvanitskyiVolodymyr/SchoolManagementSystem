namespace Domain.Core.Entities
{
    public class ClassSubjectGrade
    {
        public int ClassSubjectGradeId { get; set; }
        public GradeType GradeType { get; set; }
        public int ClassSubjectId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
    }
}
