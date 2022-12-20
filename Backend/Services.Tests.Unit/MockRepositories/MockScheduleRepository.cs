using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockScheduleRepository : Mock<IScheduleRepository>
    {
        public void GetScheduleForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId, IEnumerable<ScheduleWithSubject> output)
        {
            Setup(x => x.GetScheduleForStudentByPeriod
                (It.Is<DateTime>(i => i == startDateTime), 
                It.Is<DateTime>(i => i == endDateTime),
                It.Is<int>(i => i == studentId)))
                .ReturnsAsync(output);
        }

        public void MockCheckIsTimeFrameFree_AlwaysTrue(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            Setup(x => x.CheckIsTimeFrameFree(
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<int>()))
                .ReturnsAsync(true);
        }

        public void MockCheckIsTimeFrameFree_AlwaysFalse(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            Setup(x => x.CheckIsTimeFrameFree(
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<int>()))
                .ReturnsAsync(false);
        }

        public void InsertSchedule(InsertScheduleDto scheduleDto, int output)
        {
            Setup(x => x.InsertSchedule(
                It.Is<InsertScheduleDto>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(scheduleDto))))
                .ReturnsAsync(output);
        }
    }
}
