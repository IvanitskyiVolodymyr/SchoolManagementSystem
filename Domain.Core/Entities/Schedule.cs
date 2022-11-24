namespace Domain.Core.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public int ClassSubjectId { get; set; }
        public DateTime EndTime { get; set; }
        public string Place { get; set; }
    }
}
