namespace Common.Dtos.Schedule
{
    public class ScheduleWithClassSubjectDto : ScheduleWithSubject
    {
        public string ClassNumber { get; set; }
        public string ClassLetter { get; set; }
    }
}
