using Domain.Core.Entities;

namespace Common.Dtos.Attendance
{
    public class UpdateAttendanceDto
    {
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
