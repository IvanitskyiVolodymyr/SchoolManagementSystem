
namespace Common.Dtos.Schedule
{
    public class ScheduleGenerationDto
    {
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public List<DayOfWeek> TeacherDaysOff{ get; set; }

        //Add Enum subject priority
    }
}
