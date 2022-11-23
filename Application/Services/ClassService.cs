using Application.Interfaces;
using Common.Dtos.Class;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<int> CreateClass(InsertClassDto classDto)
        {
            return await _classRepository.InsertClass(classDto);
        }
    }
}
