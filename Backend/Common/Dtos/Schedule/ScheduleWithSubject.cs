namespace Common.Dtos.Schedule
{
    public class ScheduleWithSubject
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public int ClassSubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime EndTime { get; set; }
        public string Place { get; set; }
    }
}
