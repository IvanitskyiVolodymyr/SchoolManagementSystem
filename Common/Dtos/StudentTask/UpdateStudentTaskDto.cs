namespace Common.Dtos.StudentTask
{
    public class UpdateStudentTaskDto
    {
        public int StudentId { get; set; }
        public int TaskId { get; set; }
        public bool IsDone { get; set; }
        public bool ISChecked { get; set; }
        public bool IsNeededToBeRedone { get; set; }
    }
}
