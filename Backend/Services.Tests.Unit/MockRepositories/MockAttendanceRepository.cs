using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Moq;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockAttendanceRepository : Mock<IAttendanceRepository>
    {
        public void GetAttendancesForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId, IEnumerable<Attendance> output)
        {
            Setup(x => x.GetAttendancesForStudentByPeriod
                (It.Is<DateTime>(i => i == startDateTime),
                It.Is<DateTime>(i => i == endDateTime),
                It.Is<int>(i => i == studentId)))
                .ReturnsAsync(output);
        }
    }
}
