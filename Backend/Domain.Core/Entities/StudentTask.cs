namespace Domain.Core.Entities
{
    public class StudentTask
    {
        public int StudentTaskId { get; set; }
        public int StudentId { get; set; }
        public int TaskId { get; set; }
        public bool IsDone { get; set; }
        public bool IsChecked { get; set; }
        public bool IsNeededToBeRedone { get; set; }
    }
}
