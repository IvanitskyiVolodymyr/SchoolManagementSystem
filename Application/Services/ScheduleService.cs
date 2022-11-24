using Application.Interfaces;
using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<IEnumerable<Schedule>> GenerateSchedule(DateTime from, DateTime to, IList<ScheduleGenerationDto> scheduleGenerationDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Schedule>> GetScheduleForClassByPeriod(DateTime startTime, DateTime endTime, int classId)
        {
            return await _scheduleRepository.GetScheduleForClassByPeriod(startTime, endTime, classId);
        }

        public async Task<IEnumerable<Schedule>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId)
        {
            return await _scheduleRepository.GetScheduleForTeacherByPeriod(startTime, endTime, teacherId);
        }

        public async Task<int> InsertSchedule(InsertScheduleDto scheduleDto)
        {
            return await _scheduleRepository.InsertSchedule(scheduleDto);
        }

        public async Task InsertScheduleRange(IList<InsertScheduleDto> scheduleRange)
        {
            await _scheduleRepository.InsertScheduleRange(scheduleRange);
        }

        public async Task<int> UpdateSchedule(Schedule schedule)
        {
            return await _scheduleRepository.UpdateSchedule(schedule);
        }
    }
}
