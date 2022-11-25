using Domain.Core.Entities;

namespace Common.Dtos.Attendance
{
    public class InsertAttendanceDto
    {
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
