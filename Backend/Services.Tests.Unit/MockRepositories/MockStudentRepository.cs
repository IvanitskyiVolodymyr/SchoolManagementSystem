using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockStudentRepository : Mock<IStudentRepository>
    {
        public void CreateStudent(InsertStudentDto studentDto, int output)
        {
            Setup(x => x.CreateStudent(It.Is<InsertStudentDto>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(studentDto))))
                .ReturnsAsync(output);
        }
    }
}
