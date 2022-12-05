namespace Common.Dtos.Schedule
{
    public class InsertScheduleDto
    {
        public DateTime StartTime { get; set; }
        public int ClassSubjectId { get; set; }
        public DateTime EndTime { get; set; }
        public string Place { get; set; }
    }
}
