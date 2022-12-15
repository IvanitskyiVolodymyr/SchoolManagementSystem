using Domain.Core.Entities;

namespace Common.Dtos.Tasks
{
    public class ResponseTaskWithGradeDto
    {
        public int StudentTaskId { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ScheduleId { get; set; }
        public int? GradeValue { get; set; }

        public bool IsChecked { get; set; }
        public bool IsDone { get; set; }
        public bool IsNeededToBeRedone { get; set; }

        public string SubjectTitle { get; set; }
    }
}
