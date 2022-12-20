using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockTeacherRepository : Mock<ITeacherRepository>
    {
        public void CreateTeacher(InsertTeacherDto teacherDto, int output)
        {
            Setup(x => x.CreateTeacher(It.Is<InsertTeacherDto>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(teacherDto))))
                .ReturnsAsync(output);
        }
    }
}
