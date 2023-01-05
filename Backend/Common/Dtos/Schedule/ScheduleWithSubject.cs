namespace Common.Dtos.Schedule
{
    public class ScheduleWithSubject : Domain.Core.Entities.Schedule
    {
        public string SubjectName { get; set; }
    }
}
