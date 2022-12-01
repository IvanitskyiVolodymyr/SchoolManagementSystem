using Domain.Core.Entities;

namespace Common.Dtos.Tasks
{
    public class ResponseTeacherTaskDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int StudentTaskId { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
