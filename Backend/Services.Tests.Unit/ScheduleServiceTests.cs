using Application.Interfaces;
using Application.Services;
using Common.Dtos.Schedule;
using Common.Exceptions.Schedule;
using Domain.Core.Entities;
using Newtonsoft.Json;
using Services.Tests.Unit.MockRepositories;

namespace Services.Tests.Unit
{
    public class ScheduleServiceTests
    {

        [Fact]
        public async void GetScheduleForStudentWithAttendancesByPeriod_WithCorrectData_ReturnsListOfScheduleAttendances()
        {
            DateTime startDateTime = new DateTime(2022, 12, 1, 0, 0, 0);
            DateTime endDateTime = new DateTime(2022, 12, 2, 11, 0, 0);
            int studentId = 1;

            var scheduleOutput = GetSchedulesWithSubject();

            var mockScheduleRepository = new MockScheduleRepository();
            mockScheduleRepository.GetScheduleForStudentByPeriod(startDateTime, endDateTime, studentId, scheduleOutput);

            var attendanceOutput = GetAttendances().Where(s => s.StudentId == studentId);

            var mockAttendanceRepository = new MockAttendanceRepository();
            mockAttendanceRepository.GetAttendancesForStudentByPeriod(startDateTime, endDateTime, studentId, attendanceOutput);

            IScheduleService scheduleService = new ScheduleService(mockScheduleRepository.Object, mockAttendanceRepository.Object);

            var expected = new List<ScheduleAttendanceDto>
            {
                new ScheduleAttendanceDto
                {
                    ScheduleId = 1,
                    ClassSubjectId = 1,
                    StartTime = new DateTime(2022,12,1,10,0,0),
                    EndTime = new DateTime(2022,12,1,10,45,0),
                    Place = "link",
                    SubjectName = "math",
                    Status = AttendanceStatus.Present,
                },
                new ScheduleAttendanceDto
                {
                    ScheduleId = 2,
                    ClassSubjectId = 2,
                    StartTime = new DateTime(2022,12,1,11,0,0),
                    EndTime = new DateTime(2022,12,1,11,45,0),
                    Place = "link",
                    SubjectName = "english",
                    Status = AttendanceStatus.Absent
                },
                new ScheduleAttendanceDto
                {
                    ScheduleId = 3,
                    ClassSubjectId = 1,
                    StartTime = new DateTime(2022,12,2,10,0,0),
                    EndTime = new DateTime(2022,12,2,10,45,0),
                    Place = "link",
                    SubjectName = "math",
                    Status = AttendanceStatus.Present
                },
                new ScheduleAttendanceDto
                {
                    ScheduleId = 4,
                    ClassSubjectId = 2,
                    StartTime = new DateTime(2022,12,2,12,0,0),
                    EndTime = new DateTime(2022,12,2,12,45,0),
                    Place = "link",
                    SubjectName = "english",
                    Status = null
                }
            };

            Assert.Equal(
                JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(await scheduleService.GetScheduleForStudentWithAttendancesByPeriod(startDateTime, endDateTime, studentId))
                );
        }

        [Fact]
        public async void InsertSchedule_WithFreeTimeFrame_ReturnsId()
        {
            var mockScheduleRepository = new MockScheduleRepository();
            mockScheduleRepository.MockCheckIsTimeFrameFree_AlwaysTrue(new DateTime(), new DateTime(), 1);
            mockScheduleRepository.InsertSchedule(new InsertScheduleDto(), 1);

            IScheduleService scheduleService = new ScheduleService(mockScheduleRepository.Object, null);

            var actualInsertedId = await scheduleService.InsertSchedule(new InsertScheduleDto());
            var excepted = 1;
            Assert.Equal(excepted, actualInsertedId);
        }

        [Fact]
        public async void InsertSchedule_WithUsedTimeFrame_ThrowsUsedTimeFrameException()
        {
            var mockScheduleRepository = new MockScheduleRepository();
            mockScheduleRepository.MockCheckIsTimeFrameFree_AlwaysFalse(new DateTime(), new DateTime(), 1);
            mockScheduleRepository.InsertSchedule(new InsertScheduleDto(), 1);

            IScheduleService scheduleService = new ScheduleService(mockScheduleRepository.Object, null);

            await Assert.ThrowsAsync<UsedTimeFrameException>(async () => await scheduleService.InsertSchedule(new InsertScheduleDto()));

        }

        private List<ScheduleWithSubject> GetSchedulesWithSubject()
        {
            return new List<ScheduleWithSubject>
            {
                new ScheduleWithSubject
                {
                    ScheduleId = 1,
                    ClassSubjectId = 1,
                    StartTime = new DateTime(2022,12,1,10,0,0),
                    EndTime = new DateTime(2022,12,1,10,45,0),
                    Place = "link",
                    SubjectName = "math"
                },
                new ScheduleWithSubject
                {
                    ScheduleId = 2,
                    ClassSubjectId = 2,
                    StartTime = new DateTime(2022,12,1,11,0,0),
                    EndTime = new DateTime(2022,12,1,11,45,0),
                    Place = "link",
                    SubjectName = "english"
                },
                new ScheduleWithSubject
                {
                    ScheduleId = 3,
                    ClassSubjectId = 1,
                    StartTime = new DateTime(2022,12,2,10,0,0),
                    EndTime = new DateTime(2022,12,2,10,45,0),
                    Place = "link",
                    SubjectName = "math"
                },
                new ScheduleWithSubject
                {
                    ScheduleId = 4,
                    ClassSubjectId = 2,
                    StartTime = new DateTime(2022,12,2,12,0,0),
                    EndTime = new DateTime(2022,12,2,12,45,0),
                    Place = "link",
                    SubjectName = "english"
                }
            };
        }

        private List<Attendance> GetAttendances()
        {
            return new List<Attendance>
            {
                new Attendance
                {
                    AttendanceId = 1,
                    ScheduleId =1,
                    Status = AttendanceStatus.Present,
                    StudentId = 1
                },
                new Attendance
                {
                    AttendanceId = 2,
                    ScheduleId =1,
                    Status = AttendanceStatus.Absent,
                    StudentId = 2
                },
                new Attendance
                {
                    AttendanceId = 3,
                    ScheduleId =2,
                    Status = AttendanceStatus.Absent,
                    StudentId = 1
                },
                new Attendance
                {
                    AttendanceId = 4,
                    ScheduleId =3,
                    Status = AttendanceStatus.Present,
                    StudentId = 1
                }
            };
        }
    }
}
