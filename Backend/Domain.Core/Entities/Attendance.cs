namespace Domain.Core.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
