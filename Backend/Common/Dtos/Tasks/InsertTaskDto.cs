using Domain.Core.Entities;

namespace Common.Dtos.Tasks
{
    public class InsertTaskDto
    {
        public int ScheduleId { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
