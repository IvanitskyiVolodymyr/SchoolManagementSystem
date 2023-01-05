
using Domain.Core.Entities;

namespace Common.Dtos.Schedule
{
    public class ScheduleAttendanceDto : ScheduleWithSubject
    {
        public AttendanceStatus? Status { get; set; }
    }
}
