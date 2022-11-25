
using Domain.Core.Entities;

namespace Common.Dtos.Schedule
{
    public class ScheduleAttendanceDto
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public int ClassSubjectId { get; set; }
        public DateTime EndTime { get; set; }
        public string Place { get; set; }
        public AttendanceStatus? Status { get; set; }
    }
}
