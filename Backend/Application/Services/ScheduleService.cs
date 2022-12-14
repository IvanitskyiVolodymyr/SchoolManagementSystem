using Application.Interfaces;
using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Common.Exceptions.Schedule;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public ScheduleService(IScheduleRepository scheduleRepository, IAttendanceRepository attendanceRepository)
        {
            _scheduleRepository = scheduleRepository;
            _attendanceRepository = attendanceRepository;
        }

        public Task<IEnumerable<Schedule>> GenerateSchedule(DateTime from, DateTime to, IList<ScheduleGenerationDto> scheduleGenerationDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            return await _attendanceRepository.GetAttendancesForClassSubjectByPeriod(startDateTime, endDateTime, classSubjectId);
        }

        public async Task<IEnumerable<ScheduleWithSubject>> GetScheduleForStudentByPeriod(DateTime startTime, DateTime endTime, int studentId)
        {
            return await _scheduleRepository.GetScheduleForStudentByPeriod(startTime, endTime, studentId);
        }

        public async Task<IEnumerable<ScheduleAttendanceDto>> GetScheduleForStudentWithAttendancesByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            var studentSchedule = await _scheduleRepository.GetScheduleForStudentByPeriod(startDateTime, endDateTime, studentId);
            var studentAttendances = await _attendanceRepository.GetAttendancesForStudentByPeriod(startDateTime, endDateTime, studentId);

            return (from left in studentSchedule
                    join right in studentAttendances on left.ScheduleId equals right.ScheduleId into joinedList
                         from sub in joinedList.DefaultIfEmpty()
                         select new ScheduleAttendanceDto
                         {
                             ScheduleId = left.ScheduleId,
                             StartTime = left.StartTime,
                             EndTime = left.EndTime,
                             ClassSubjectId = left.ClassSubjectId,
                             SubjectName = left.SubjectName,
                             Place = left.Place,
                             Status = sub?.Status   
                         }).ToList();
        }

        public async Task<IEnumerable<ScheduleWithClassSubjectDto>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId)
        {
            return await _scheduleRepository.GetScheduleForTeacherByPeriod(startTime, endTime, teacherId);
        }

        public async Task<List<int>> InsertAttendances(IList<InsertAttendanceDto> attendances, int scheduleId)
        {
            return await _attendanceRepository.InsertAttendances(attendances, scheduleId);
        }

        public async Task<int> InsertSchedule(InsertScheduleDto scheduleDto)
        {
            bool isTimeFrameFree = await _scheduleRepository.CheckIsTimeFrameFree(scheduleDto.StartTime, scheduleDto.EndTime, scheduleDto.ClassSubjectId);

            if (!isTimeFrameFree)
            {
                throw new UsedTimeFrameException();
            }

            return await _scheduleRepository.InsertSchedule(scheduleDto);
        }

        public async Task InsertScheduleRange(IList<InsertScheduleDto> scheduleRange)
        {
            await _scheduleRepository.InsertScheduleRange(scheduleRange);
        }

        public async Task<int> UpdateAttendance(UpdateAttendanceDto attendance)
        {
            return await _attendanceRepository.UpdateAttendance(attendance);
        }

        public async Task<int> UpdateSchedule(Schedule schedule)
        {
            return await _scheduleRepository.UpdateSchedule(schedule);
        }
    }
}
